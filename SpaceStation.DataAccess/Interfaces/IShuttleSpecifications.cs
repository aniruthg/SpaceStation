using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SpaceStation.Models.Interfaces;

namespace SpaceStation.DataAccess.Interfaces
{
    public interface IShuttleSpecifications
    {
        bool CheckSpecifications(IShuttle shuttle);

        IShuttle GetShuttle(string shuttleId);

        Task<bool> DockShuttle(IShuttle shuttle);

        Task<bool> UndockShuttle(string shuttleId);

    }
}
