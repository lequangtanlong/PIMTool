using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIMToolCodeBase.Dtos
{
    public class EmployeeDto
    {
        public decimal Id { get; set; }

        public string Visa { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDay { get; set; }

        public decimal Version { get; set; }

        public GroupDto Group { get; set; }

        public ICollection<ProjectEmployeeDto> ProjectEmployees { get; set; }
    }
}
