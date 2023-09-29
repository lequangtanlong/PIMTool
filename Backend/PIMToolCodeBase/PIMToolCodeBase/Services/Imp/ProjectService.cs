using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PIMToolCodeBase.Repositories;
using PIMToolCodeBase.Domain.Entities;
using PIMToolCodeBase.Domain.Objects;

namespace PIMToolCodeBase.Services.Imp
{
    public class ProjectService: BaseService, IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        //private readonly IProjectEmployeeRepository _projectEmployeeRepository;

        //public ProjectService(IProjectRepository projectRepository, IProjectEmployeeRepository projectEmployeeRepository)
        //{
        //    _projectRepository = projectRepository;
        //    _projectEmployeeRepository = projectEmployeeRepository;
        //}

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
            //_projectEmployeeRepository = projectEmployeeRepository;
        }

        public IEnumerable<Project> Get()
        {
            IEnumerable<Project> listProject = _projectRepository.Get();
            //foreach (var project in listProject)
            //{
            //    project.ProjectEmployees = _projectEmployeeRepository.GetById(project.Id).ToList();
            //}
            return listProject;
        }

        public Project GetProject(decimal id)
        {
            return _projectRepository.GetProject(id);
        }

        public IEnumerable<Project> GetProjectWithKeySearch(string input, int status)
        {
            return _projectRepository.Get().Where(p => (String.IsNullOrEmpty(input) || p.ProjectNumber.ToString() == input || p.Name.ToLower().Contains(input.ToLower()) || p.Customer.ToLower().Contains(input.ToLower())) && (p.Status.ToLower() == ((Status)status).ToString().ToLower()));
        }

        public void Add(Project project)
        {
            try
            {
                _projectRepository.Add(project);
                _projectRepository.SaveChange();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DeleteProjects(params decimal[] ids)
        {
            var project = _projectRepository.GetByIds(ids);
            //_projectEmployeeRepository.Delete(ids);
            _projectRepository.Delete(ids);
            _projectRepository.SaveChange();
            if (project.Count() == 0)
                throw new Exception("Project is not exists in database.");
        }

        public bool ProjectExists(decimal projectNumber)
        {
            return _projectRepository.ProjectExists(projectNumber);
        }

        public int CountProjects(string input, int status)
        {
            return _projectRepository.Get().Where(p => (String.IsNullOrEmpty(input) || p.ProjectNumber.ToString() == input || p.Name.ToLower().Contains(input.ToLower()) || p.Customer.ToLower().Contains(input.ToLower()))).Count();
        }
    }
}
