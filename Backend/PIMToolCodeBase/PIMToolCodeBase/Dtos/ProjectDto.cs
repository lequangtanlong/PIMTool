﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIMToolCodeBase.Dtos
{
    public class ProjectDto
    {
        public decimal Id { get; set; }

        public decimal GroupId { get; set; }

        public GroupDto Group { get; set; }

        public decimal ProjectNumber { get; set; }

        public string Name { get; set; }

        public string Customer { get; set; }

        public string Status { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public decimal Version { get; set; }

        public ICollection<ProjectEmployeeDto> ProjectEmployees { get; set; }
    }
}
