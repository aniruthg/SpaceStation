using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SpaceStation.Models;

namespace SpaceStation.Repository.Interfaces
{
    public interface IDimensionRepository
    {
        Dimension GetDimension(string dimensionId);

        List<Dimension> GetDimensions();

        Task<bool> AddDimension(Dimension dimension);
    }
}
