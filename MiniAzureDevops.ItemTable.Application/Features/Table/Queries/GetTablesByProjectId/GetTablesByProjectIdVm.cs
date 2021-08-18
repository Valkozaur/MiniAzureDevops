using MiniAzureDevops.ItemTable.Application.Mapping;

namespace MiniAzureDevops.ItemTable.Application.Features.Table.Queries.GetTablesByProjectId
{
    public class GetTablesByProjectIdVm : IMapFrom<Domain.Entities.Table>
    {
        public Guid TableId { get; set; }

        public string Name { get; set; }
    }
}
