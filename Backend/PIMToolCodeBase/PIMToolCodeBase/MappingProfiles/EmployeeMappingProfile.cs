using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PIMToolCodeBase.Dtos;
using System.Text.RegularExpressions;
using PIMToolCodeBase.Domain.Entities;

namespace PIMToolCodeBase.MappingProfiles
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile() : base(nameof(EmployeeMappingProfile))
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
        }
    }
}
