using AutoMapper;

using MiniAzureDevops.ItemTable.Domain.Entities;
using MiniAzureDevops.ItemTable.Application.Features.Column.Commands.CreateColumn;
using MiniAzureDevops.ItemTable.Application.Features.Column.Commands.UpdateColumn;
using MiniAzureDevops.ItemTable.Application.Features.Column.Queries.GetColumnsByTableId;

using MiniAzureDevops.ItemTable.Application.Features.Project.Commands.CreateProject;
using MiniAzureDevops.ItemTable.Application.Features.Project.Queries.GetProjectById;

using MiniAzureDevops.ItemTable.Application.Features.Story.Commands.CreateStory;
using MiniAzureDevops.ItemTable.Application.Features.Table.Commands.CreateTable;
using MiniAzureDevops.ItemTable.Application.Features.Table.Queries.GetTableById;

namespace MiniAzureDevops.ItemTable.Application.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //Project
            CreateMap<Project, CreateProjectDto>();
            CreateMap<Project, GetProjectByIdDto>();

            //Table
            CreateMap<CreateTableCommand, Table>();
            CreateMap<Table, CreateTableDto>();
            CreateMap<Table, TableVm>().ReverseMap();

            //Column
            CreateMap<CreateColumnCommand, Column>();
            CreateMap<Column, CreateColumnDto>();
            CreateMap<Column, ColumnVm>();
            CreateMap<UpdateColumnCommand, Column>();

            //Item
            CreateMap<CreateItemCommand, GetItemByIdDto>();
            CreateMap<UpdateColumnCommand, GetItemByIdDto>();
            CreateMap<Column, GetItemByIdDto>();
        }
    }
}
