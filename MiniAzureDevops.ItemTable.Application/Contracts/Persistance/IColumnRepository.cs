using MiniAzureDevops.ItemTable.Domain.Entities;

namespace MiniAzureDevops.ItemTable.Application.Contracts.Persistance
{
    public interface IColumnRepository : IAsyncRepository<Column>
    {
    }
}
