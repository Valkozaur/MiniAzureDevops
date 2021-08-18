using MiniAzureDevops.ItemTable.Application.Mapping;

namespace MiniAzureDevops.ItemTable.Application.Features.Table.Queries.GetTableById
{
    public class GetTableByIdVm : IMapFrom<Domain.Entities.Table>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}