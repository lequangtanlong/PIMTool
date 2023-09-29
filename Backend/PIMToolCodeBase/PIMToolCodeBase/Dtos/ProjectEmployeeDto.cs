using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIMToolCodeBase.Dtos
{
    public class ProjectEmployeeDto
    {
        public decimal ProjectId { get; set; }

        public ProjectDto Project { get; set; }

        public decimal EmployeeId { get; set; }

        public EmployeeDto Employee { get; set; }
    }
}
