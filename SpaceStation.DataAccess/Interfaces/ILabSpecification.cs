using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SpaceStation.Models.Models;

namespace SpaceStation.DataAccess.Interfaces
{
    public interface ILabSpecification
    {
        bool CheckSpecifications(Lab lab);

        List<Lab> GetLabs();

        Lab GetLab(string labId);

        Task<bool> ChangeLabStatus(Lab lab);

        Task<bool> AddLab(Lab lab);
    }
}
