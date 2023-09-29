using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PIMToolCodeBase.Database;
using PIMToolCodeBase.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace PIMToolCodeBase.Repositories.Imp
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(PimContext pimContext) : base(pimContext)
        {
        }

        public void Attach(Project project)
        {
            Set.Attach(project);
        }

        public int CountProjects()
        {
            return Set.Count();
        }

        public IEnumerable<Project> GetByIds(params decimal[] ids)
        {
            return Set.Where(x => ids.Contains(x.Id)).ToList();
        }

        public Project GetProject(decimal id)
        {
            return Set.Include(e => e.ProjectEmployees).FirstOrDefault(x => x.Id == id);
        }


        public Project GetInclude(decimal id)
        {
            return Set.Where(p => p.Id == id).Include(e => e.ProjectEmployees).FirstOrDefault();
        }

        public bool ProjectExists(decimal projectNumber)
        {
            return Set.Any(p => p.ProjectNumber == projectNumber);
        }
    }
}
