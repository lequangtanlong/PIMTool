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

namespace PIMToolCodeBase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGroupService _groupService;

        public GroupsController(IGroupService groupService, IMapper mapper)
        {
            _mapper = mapper;
            _groupService = groupService;
        }

        // GET: api/Groups
        [HttpGet]
        public IEnumerable<GroupDto> Get()
        {
            return _mapper.Map<IEnumerable<Group>, IEnumerable<GroupDto>>(_groupService.Get());
        }

        //// GET: api/Groups/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Group>> GetGroup(decimal id)
        //{
        //    var @group = await _context.Groups.FindAsync(id);

        //    if (@group == null)
        //    {
        //        return NotFound();
        //    }

        //    return @group;
        //}

        //// PUT: api/Groups/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutGroup(decimal id, Group @group)
        //{
        //    if (id != @group.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(@group).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!GroupExists(id))
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

        //// POST: api/Groups
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Group>> PostGroup(Group @group)
        //{
        //    _context.Groups.Add(@group);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetGroup", new { id = @group.Id }, @group);
        //}

        //// DELETE: api/Groups/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteGroup(decimal id)
        //{
        //    var @group = await _context.Groups.FindAsync(id);
        //    if (@group == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Groups.Remove(@group);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool GroupExists(decimal id)
        //{
        //    return _context.Groups.Any(e => e.Id == id);
        //}
    }
}
