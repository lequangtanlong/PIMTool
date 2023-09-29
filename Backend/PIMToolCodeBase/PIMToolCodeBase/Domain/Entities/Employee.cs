using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIMToolCodeBase.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string Visa { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDay { get; set; }

        public decimal Version { get; set; }

        public Group Group { get; set; }

        public ICollection<ProjectEmployee> ProjectEmployees { get; set; }
    }
}
