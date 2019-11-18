using System;
using System.Collections.Generic;
using System.Text;
using SpaceStation.Models.Interfaces;

namespace SpaceStation.Models.Models
{
    public class Dimensions : IDimensions
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double Diameter { get; set; }
        public double Length { get; set; }
    }
}
