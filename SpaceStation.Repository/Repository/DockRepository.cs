using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceStation.Models;
using SpaceStation.Repository.Interfaces;

namespace SpaceStation.Repository.Repository
{
    public class DockRepository :IDockRepository
    {
        private readonly  SpaceContext _spaceContext;
        public DockRepository(SpaceContext spaceContext)
        {
            _spaceContext = spaceContext;
        }

        public async Task<bool> Dock(Shuttle shuttles)
        {
            await _spaceContext.Shuttles.AddRangeAsync(shuttles);
            return await SaveChanges();
        }

        public async Task<bool> UnDock(string shuttleId)
        {
            var shuttle = GetShuttle(shuttleId);
            _spaceContext.Shuttles.Remove(shuttle);
            return await SaveChanges();
        }

        private async Task<bool> SaveChanges()
        {
            var result = await _spaceContext.SaveChangesAsync();
            return result > 0;
        }

        public Shuttle GetShuttle(string shuttleId)
        {
            return _spaceContext.Shuttles.FirstOrDefault(x => x.ShuttleId == shuttleId);
        }

        public List<Shuttle> GetShuttles()
        {
            return _spaceContext.Shuttles.ToList();
        }
    }
}
