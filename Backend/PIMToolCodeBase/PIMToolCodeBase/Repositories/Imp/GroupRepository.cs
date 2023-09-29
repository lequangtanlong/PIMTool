using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PIMToolCodeBase.Database;
using PIMToolCodeBase.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace PIMToolCodeBase.Repositories.Imp
{
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public GroupRepository(PimContext pimContext) : base(pimContext)
        {
        }
    }
}