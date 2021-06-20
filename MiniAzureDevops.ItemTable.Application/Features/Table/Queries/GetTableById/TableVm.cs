using MiniAzureDevops.ItemTable.Application.Common.Extensions.Mapping;
using System;

namespace MiniAzureDevops.ItemTable.Application.Features.Table.Queries.GetTableById
{
    public class TableVm : IMapFrom<Domain.Entities.Table>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}