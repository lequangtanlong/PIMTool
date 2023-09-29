using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIMToolCodeBase.Domain.Entities
{
    public class Group: BaseEntity
    {
        public decimal GroupLeaderId { get; set; }

        public Employee GroupLeader { get; set; }

        public decimal Version { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}
