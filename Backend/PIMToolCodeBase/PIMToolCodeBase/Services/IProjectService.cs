using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PIMToolCodeBase.Domain.Entities;
using PIMToolCodeBase.Domain.Objects;

namespace PIMToolCodeBase.Services
{
    public interface IProjectService
    {
        IEnumerable<Project> Get();

        Project GetProject(decimal id);

        IEnumerable<Project> GetProjectWithKeySearch(string input, int status);

        void Add(Project project);

        void DeleteProjects(params decimal[] id);

        bool ProjectExists(decimal projectNumber);

        int CountProjects(string input, int status);
    }
}
