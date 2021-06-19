﻿using AutoMapper;
using MiniAzureDevops.ItemTable.Application.Features.Table.Queries.GetTableById;
using MiniAzureDevops.ItemTable.Domain.Entities;

namespace MiniAzureDevops.ItemTable.Application.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Table, TableVm>().ReverseMap();
        }
    }
}
