using MiniAzureDevops.ItemTable.Application.Mapping;

namespace MiniAzureDevops.ItemTable.Application.Features.Column.Commands.CreateColumn
{
    public class CreateColumnVm : IMapFrom<Domain.Entities.Column>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid TableId { get; set; }
    }
}