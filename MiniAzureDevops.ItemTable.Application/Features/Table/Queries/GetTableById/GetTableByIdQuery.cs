using MediatR;
using System;

namespace MiniAzureDevops.ItemTable.Application.Features.Table.Queries.GetTableById
{
    public class GetTableByIdQuery : IRequest<TableVm>
    {
        public Guid Id { get; set; }
    }
}
