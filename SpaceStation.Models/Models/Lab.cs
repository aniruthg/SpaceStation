using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Models
{
    public class Lab
    {
        public string LabId { get; set; }
        public Dimensions Dimensions { get; set; }
        public string LabStatus { get; set; }
        public double Weight { get; set; }
    }

    public enum LabStatus
    {
        Online=0,
        Offline=1,
        Attach=2,
        Detach=3,
        Destroy=4
    }
}
