using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PIMToolCodeBase.Domain.Entities;

namespace PIMToolCodeBase.Repositories
{
    public interface IProjectEmployeeRepository
    {
        IEnumerable<ProjectEmployee> Add(ICollection<ProjectEmployee> entities);

        IEnumerable<ProjectEmployee> GetById(decimal id);

        void Delete(params decimal[] ids);

        void Delete(ICollection<ProjectEmployee> entities);

        void SaveChange();
    }
}
