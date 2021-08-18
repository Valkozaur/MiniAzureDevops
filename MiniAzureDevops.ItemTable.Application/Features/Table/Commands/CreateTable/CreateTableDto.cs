using MiniAzureDevops.ItemTable.Application.Mapping;

namespace MiniAzureDevops.ItemTable.Application.Features.Table.Commands.CreateTable
{
    public class CreateTableDto : IMapFrom<Domain.Entities.Table>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
