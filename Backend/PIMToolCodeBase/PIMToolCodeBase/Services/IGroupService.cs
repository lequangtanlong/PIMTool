using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PIMToolCodeBase.Domain.Entities;

namespace PIMToolCodeBase.Services
{
    public interface IGroupService
    {
        IEnumerable<Group> Get();
    }
}