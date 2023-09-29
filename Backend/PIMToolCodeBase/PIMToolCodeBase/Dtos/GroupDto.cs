using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIMToolCodeBase.Dtos
{
    public class GroupDto
    {
        public decimal Id { get; set; }

        public decimal GroupLeaderId { get; set; }

        public EmployeeDto GroupLeader { get; set; }

        public decimal Version { get; set; }

        public ICollection<ProjectDto> Projects { get; set; }
    }
}
