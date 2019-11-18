using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        }

        public Dimension GetDimension(string dimensionId)
        {
            return _spaceContext.Dimensions.FirstOrDefault(x => x.DimensionId == dimensionId);
        }

        public List<Dimension> GetDimensions()
        {
            return _spaceContext.Dimensions.ToList();
        }
    }
}
