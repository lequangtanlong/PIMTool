using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PIMToolCodeBase.Dtos;
using PIMToolCodeBase.Domain.Entities;

namespace PIMToolCodeBase.MappingProfiles
{
    public class GroupMappingProfile : Profile
    {
        public GroupMappingProfile() : base(nameof(GroupMappingProfile))
        {
            CreateMap<Group, GroupDto>().ReverseMap();
        }
    }
}
