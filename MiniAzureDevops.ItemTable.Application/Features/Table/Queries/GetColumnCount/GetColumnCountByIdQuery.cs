using MediatR;
using System;

namespace MiniAzureDevops.ItemTable.Application.Features.Table.Queries.GetColumnCount
{
    public class GetColumnCountByIdQuery : IRequest<int>
    {
        public Guid TableId { get; set; }
    }
}
