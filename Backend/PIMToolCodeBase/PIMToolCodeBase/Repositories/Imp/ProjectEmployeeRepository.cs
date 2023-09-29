using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PIMToolCodeBase.Domain.Entities;
using PIMToolCodeBase.Database;
using Microsoft.EntityFrameworkCore;

namespace PIMToolCodeBase.Repositories.Imp
{
    public class ProjectEmployeeRepository
    {
        private readonly PimContext _pimContext;

        private readonly DbSet<ProjectEmployee> Set;

        public ProjectEmployeeRepository(PimContext pimContext)
        {
            _pimContext = pimContext;
            Set = _pimContext.Set<ProjectEmployee>();
        }

        public void Add(ICollection<ProjectEmployee> entities)
        {
            Set.AddRange(entities);
        }

        public IEnumerable<ProjectEmployee> GetById(decimal id)
        {
            return Set.Where(x => x.ProjectId == id);
        }

        public void Delete(params decimal[] ids)
        {
            Set.RemoveRange(Set.Where(x => ids.Contains(x.ProjectId)));
        }

        public void Delete(ICollection<ProjectEmployee> entities)
        {
            Set.RemoveRange(entities);
        }

        public void SaveChange()
        {
            _pimContext.SaveChanges();
        }
    }
}
