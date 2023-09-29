using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PIMToolCodeBase.Domain.Entities;
using PIMToolCodeBase.Dtos;

namespace PIMToolCodeBase.MappingProfiles
{
    public class ProjectMappingProfile : Profile
    {
        public ProjectMappingProfile() : base(nameof(ProjectMappingProfile))
        {
            CreateMap<Project, ProjectDto>().ReverseMap();
        }
    }
}
