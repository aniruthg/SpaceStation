using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Interfaces
{
    public interface IDimensions
    {
        double Width { get; set; }
        double Height { get; set; }
        double Diameter { get; set; }
        double Length { get; set; }
    }
}
