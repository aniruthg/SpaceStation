using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SpaceStation.Models;

namespace SpaceStation.Repository.Interfaces
{
    public interface ILabRepository
    {
        Task<bool> AddLab(Lab lab);

        Lab GetLab(string labId);

        List<Lab> GetLabs();

        Task<bool> SetStatus(Lab lab);
    }
}
