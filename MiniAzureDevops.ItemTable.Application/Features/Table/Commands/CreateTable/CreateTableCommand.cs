using MediatR;
using MiniAzureDevops.ItemTable.Application.Mapping;

namespace MiniAzureDevops.ItemTable.Application.Features.Table.Commands.CreateTable
{
    public class CreateTableCommand : IRequest<CreateTableDto>, IMapTo<Domain.Entities.Table>
    {
        public string Name { get; set; }

        public Guid ProjectId { get; set; }
    }
}
