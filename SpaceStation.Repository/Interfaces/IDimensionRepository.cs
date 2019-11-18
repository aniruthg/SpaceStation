using System;
using System.Collections.Generic;
using System.Text;
using SpaceStation.Models;

namespace SpaceStation.Repository.Interfaces
{
    public interface IDimensionRepository
    {
        Dimension GetDimension(string dimensionId);

        List<Dimension> GetDimensions();
    }
}
