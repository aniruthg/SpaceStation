using System;
using System.Collections.Generic;
using System.Text;
using SpaceStation.Models.Models;

namespace SpaceStation.Models.Interfaces
{
    public interface IShuttle
    {
        string ShuttleId { get; set; }

        Dimensions Dimensions { get; set; }

        bool IsDocked { get; set; }
    }
}
