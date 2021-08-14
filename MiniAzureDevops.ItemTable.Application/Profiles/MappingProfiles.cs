using AutoMapper;

using MiniAzureDevops.ItemTable.Application.Features.Column.Commands.CreateColumn;
using MiniAzureDevops.ItemTable.Application.Features.Column.Queries.GetColumnsByTableId;
using MiniAzureDevops.ItemTable.Application.Features.Table.Commands.CreateTable;
using MiniAzureDevops.ItemTable.Application.Features.Table.Queries.GetTableById;
using MiniAzureDevops.ItemTable.Domain.Entities;

namespace MiniAzureDevops.ItemTable.Application.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Table, TableVm>().ReverseMap();
            CreateMap<CreateTableCommand, Table>();
            CreateMap<Table, CreateTableDto>();

            CreateMap<Column, CreateColumnDto>();
            CreateMap<CreateColumnCommand, Column>();
            CreateMap<Column, ColumnVm>();

            
        }
    }
}
