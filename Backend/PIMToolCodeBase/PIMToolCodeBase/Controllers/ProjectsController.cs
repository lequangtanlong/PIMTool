using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIMToolCodeBase.Database;
using PIMToolCodeBase.Domain.Entities;
using PIMToolCodeBase.Services;
using AutoMapper;
using PIMToolCodeBase.Dtos;
using PIMToolCodeBase.Domain.Objects;

namespace PIMToolCodeBase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }

        // GET: api/Projects
        [HttpGet]
        public IEnumerable<ProjectDto> GetProjects()
        {
            return _mapper.Map<IEnumerable<Project>, IEnumerable<ProjectDto>>(_projectService.Get());
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public ProjectDto GetProject(decimal id)
        {
            return _mapper.Map<Project, ProjectDto>(_projectService.GetProject(id));
        }

        // GET: api/Projects/KeySearch
        [HttpGet("KeySearch")]
        public IEnumerable<ProjectDto> GetProjectWithKeySearch(string input, int status)
        {
            return _mapper.Map<IEnumerable<Project>, IEnumerable<ProjectDto>>(_projectService.GetProjectWithKeySearch(input, status));
        }

        // PUT: api/Projects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutProject(decimal id, Project project)
        //{
        //    if (id != project.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(project).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProjectExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Projects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public void PostProject(ProjectDto project)
        {
            _projectService.Add(_mapper.Map<ProjectDto, Project>(project));
        }

        // DELETE: api/Projects/5
        //[HttpDelete("{id}")]
        
        //// DELETE: api/Projects/DeleteProjects
        [HttpDelete("DeleteProjects")]
        public void DeleteProjects(params decimal[] id)
        {
            _projectService.DeleteProjects(id);
        }

        private bool ProjectExists(decimal id)
        {
            return _projectService.ProjectExists(id);
        }
    }
}
