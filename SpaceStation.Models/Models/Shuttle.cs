using System;
using System.Collections.Generic;
using System.Text;
using SpaceStation.Models.Interfaces;

namespace SpaceStation.Models.Models
{
    public class Shuttle: IShuttle
    {
        public string ShuttleId { get; set; }
        public Dimensions Dimensions { get; set; }
        public bool IsDocked { get; set; }
    }
}
