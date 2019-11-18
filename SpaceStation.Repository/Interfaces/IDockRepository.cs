using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SpaceStation.Models;

namespace SpaceStation.Repository.Interfaces
{
    public interface IDockRepository
    {
        Task<bool> Dock(Shuttle shuttles);

        Task<bool> UnDock(string shuttleId);

        Shuttle GetShuttle(string shuttleId);

        List<Shuttle> GetShuttles();
    }
}
