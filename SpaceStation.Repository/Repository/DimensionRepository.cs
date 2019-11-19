using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceStation.Models;
using SpaceStation.Repository.Interfaces;

namespace SpaceStation.Repository.Repository
{
    public class DimensionRepository: IDimensionRepository
    {
        private readonly SpaceContext _spaceContext;
        public DimensionRepository(SpaceContext spaceContext)
        {
            _spaceContext = spaceContext;
            LoadDimension();
        }

        public Dimension GetDimension(string dimensionId)
        {
            return _spaceContext.Dimensions.FirstOrDefault(x => x.DimensionId == dimensionId);
        }

        public List<Dimension> GetDimensions()
        {
            return _spaceContext.Dimensions.ToList();
        }

        public async Task<bool> AddDimension(Dimension dimension)
        {
            await _spaceContext.Dimensions.AddAsync(dimension);
            var result = await _spaceContext.SaveChangesAsync();
            return result > 0;
        }

        private async void LoadDimension()
        {
            var exists = GetDimensions().FirstOrDefault(x => x.Type == "Shuttle");
            if (exists == null)
            {
                var dimension = new Dimension
                {
                    Diameter = 50,
                    DimensionId = "1",
                    Height = 35,
                    Length = 35,
                    Width = 35,
                    Type = "Shuttle"
                };

                await AddDimension(dimension);
            }
        }
    }
}
