using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models
{
    public class Lab
    {
        public string LabId { get; set; }
        public string DimensionId { get; set; }
        public double Weight { get; set; }
        public int LabStatus { get; set; }
    }
}
