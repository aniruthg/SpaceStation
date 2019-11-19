using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceStation.Models;
using SpaceStation.Repository.Interfaces;

namespace SpaceStation.Repository.Repository
{
    public class LabRepository : ILabRepository
    {
        private readonly SpaceContext _spaceContext;
        public LabRepository(SpaceContext spaceContext)
        {
            _spaceContext = spaceContext;
        }

        public async Task<bool> AddLab(Lab lab)
        {
            await _spaceContext.AddAsync(lab);
            return await SaveChanges();
        }

        public Lab GetLab(string labId)
        {
            return _spaceContext.Labs.FirstOrDefault(x => x.LabId == labId);
        }

        public List<Lab> GetLabs()
        {
            return _spaceContext.Labs.ToList();
        }

        public async Task<bool> SetStatus(Lab lab)
        {
            _spaceContext.Update(lab);
            return await SaveChanges();
        }

        private async Task<bool> SaveChanges()
        {
            var result = await _spaceContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
