using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PIMToolCodeBase.Domain.Entities;
using PIMToolCodeBase.Repositories;

namespace PIMToolCodeBase.Services.Imp
{
    public class GroupService : BaseService, IGroupService
    {
        public readonly IGroupRepository _groupRepository;

        public GroupService(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public IEnumerable<Group> Get()
        {
            return _groupRepository.Get();
        }
    }
}