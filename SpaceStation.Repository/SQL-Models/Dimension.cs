using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models
{
    public class Dimension
    {
        public string DimensionId { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Diameter { get; set; }
        public double Length { get; set; }
        public string Type { get; set; }
    }
}
