using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using SpaceStation.DataAccess.Interfaces;
using SpaceStation.Models.Interfaces;
using SpaceStation.Models.Models;
using SpaceStation.Repository.Interfaces;
using SpaceStation.Repository.Repository;

namespace SpaceStation.DataAccess.Sql_Mapping_Models
{
    public class ShuttleSpecifications : IShuttleSpecifications
    {
        private readonly IDockRepository _dockRepository;
        private readonly IDimensionRepository _dimensionRepository;

        public ShuttleSpecifications(IDockRepository dockRepository, IDimensionRepository dimensionRepository)
        {
            _dockRepository = dockRepository;
            _dimensionRepository = dimensionRepository;
        }

        public bool CheckSpecifications(IShuttle shuttle)
        {
            return  IsValidSpec(shuttle.Dimensions);
        }

        public IShuttle GetShuttle(string shuttleId)
        {
            var shuttle= _dockRepository.GetShuttle(shuttleId);
            return GetShuttle(shuttle);
        }

        public async Task<bool> DockShuttle(IShuttle shuttle)
        {
            var dbShuttle = ConvertToShuttle(shuttle);
            dbShuttle.IsDocked = true;
            return await _dockRepository.Dock(dbShuttle);
        }

        public async Task<bool> UndockShuttle(string shuttleId)
        {
            return await _dockRepository.UnDock(shuttleId);
        }

        private bool IsValidSpec(IDimensions dimensions)
        {
            var standardDimension = _dimensionRepository.GetDimensions().FirstOrDefault(x => x.Type == "Shuttle");
            return standardDimension != null && (CompareValues(standardDimension.Length, dimensions.Length)
                                                   && CompareValues(standardDimension.Width, dimensions.Width)
                                                   && CompareValues(standardDimension.Height, dimensions.Height)
                                                   && CompareValues(standardDimension.Diameter, dimensions.Diameter)) && _dockRepository.GetShuttles().Count(x => x.IsDocked)<2;
        }

        private bool CompareValues(double standardValue, double comparedValue)
        {
            return Math.Abs(standardValue - comparedValue) < 0;
        }

        private Shuttle GetShuttle(SpaceStation.Models.Shuttle shuttle)
        {
            return new Shuttle
            {
                ShuttleId = shuttle.ShuttleId,
                Dimensions = GetDimensions(shuttle.DimensionId),
                IsDocked = shuttle.IsDocked
            };
        }

        private Dimensions GetDimensions(string dimensionId)
        {
            var dimension = _dimensionRepository.GetDimension(dimensionId);
            return new Dimensions
            {
                Width = dimension.Width,
                Height = dimension.Height,
                Diameter = dimension.Diameter,
                Length = dimension.Length,
            };
        }

        private SpaceStation.Models.Shuttle ConvertToShuttle(IShuttle shuttle)
        {
            var standardDimension = _dimensionRepository.GetDimensions().FirstOrDefault(x => x.Type == "Shuttle");
            if (standardDimension != null)
                return new Models.Shuttle
                {
                    ShuttleId = shuttle.ShuttleId,
                    DimensionId = standardDimension.DimensionId,
                    IsDocked = shuttle.IsDocked
                };
            return null;
        }
    }
}
