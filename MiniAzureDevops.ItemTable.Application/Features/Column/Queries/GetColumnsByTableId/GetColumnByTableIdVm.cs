using MiniAzureDevops.ItemTable.Application.Mapping;

namespace MiniAzureDevops.ItemTable.Application.Features.Column.Queries.GetColumnsByTableId
{
    public class GetColumnByTableIdVm : IMapFrom<Domain.Entities.Column>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}