using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIMToolCodeBase.Domain.Entities
{
    public class ProjectEmployee
    {
        public decimal ProjectId { get; set; }

        public Project Project { get; set; }

        public decimal EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}
