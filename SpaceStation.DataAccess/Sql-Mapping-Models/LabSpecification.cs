using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceStation.DataAccess.Interfaces;
using SpaceStation.Models.Interfaces;
using SpaceStation.Models.Models;
using SpaceStation.Repository.Interfaces;

namespace SpaceStation.DataAccess.Sql_Mapping_Models
{
    public class LabSpecification : ILabSpecification
    {
        private readonly IDimensionRepository _dimensionRepository;
        private readonly ILabRepository _labRepository;

        public LabSpecification(ILabRepository labRepository, IDimensionRepository dimensionRepository)
        {
            _labRepository = labRepository;
            _dimensionRepository = dimensionRepository;
        }

        public bool CheckSpecifications(Lab lab)
        {
            return IsValidSpec(lab.Dimensions);
        }

        public List<Lab> GetLabs()
        {
            var labs = new List<Lab>();
            var dbLabs = _labRepository.GetLabs();
            foreach (var lab in dbLabs)
            {
                labs.Add(GetLab(lab));
            }

            return labs;
        }

        public Lab GetLab(string labId)
        {
            return GetLab(_labRepository.GetLab(labId));
        }

        public async Task<bool> ChangeLabStatus(Lab lab)
        {
            var dbLab = ConvertToLab(lab);
            return await _labRepository.SetStatus(dbLab);
        }

        public async Task<bool> AddLab(Lab lab)
        {
            var dbLab = ConvertToLab(lab);
            return await _labRepository.AddLab(dbLab);
        }

        private bool IsValidSpec(IDimensions dimensions)
        {
            var standardDimension = _dimensionRepository.GetDimensions().FirstOrDefault(x => x.Type == "Shuttle");
            return standardDimension != null && (CompareValues(standardDimension.Length, dimensions.Length)
                                                 && CompareValues(standardDimension.Width, dimensions.Width)
                                                 && CompareValues(standardDimension.Height, dimensions.Height)
                                                 && CompareValues(standardDimension.Diameter, dimensions.Diameter)) ;
        }

        private bool CompareValues(double standardValue, double comparedValue)
        {
            return Math.Abs(standardValue - comparedValue) <= 0;
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

        private SpaceStation.Models.Lab ConvertToLab(Lab lab)
        {
            var standardDimension = _dimensionRepository.GetDimensions().FirstOrDefault(x => x.Type == "Lab");
            Enum.TryParse(lab.LabStatus, out LabStatus myStatus);
            if (standardDimension != null)
                return new Models.Lab
                {
                    LabId = lab.LabId,
                    DimensionId = standardDimension.DimensionId,
                    Weight = lab.Weight,
                    LabStatus = (int)myStatus
                };
            return null;
        }

        private Lab GetLab(Models.Lab lab)
        {
            var mystatus = (LabStatus) lab.LabStatus;
            return new Lab
            {
                Dimensions = GetDimensions(lab.DimensionId),
                LabStatus =  mystatus.ToString(),
                Weight = lab.Weight,
                LabId = lab.LabId
            };
        }
    }
}
