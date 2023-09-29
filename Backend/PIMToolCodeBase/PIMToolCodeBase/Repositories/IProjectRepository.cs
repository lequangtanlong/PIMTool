using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PIMToolCodeBase.Domain.Entities;

namespace PIMToolCodeBase.Repositories
{
    public interface IProjectRepository : IRepository<Project>
    {
        Project GetInclude(decimal id);

        Project GetProject(decimal id);

        void Attach(Project project);
        
        IEnumerable<Project> GetByIds(params decimal[] ids);

        bool ProjectExists(decimal projectNumber);

        int CountProjects();
    }
}
