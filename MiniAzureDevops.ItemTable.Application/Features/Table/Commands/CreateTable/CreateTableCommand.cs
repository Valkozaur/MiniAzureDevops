using MediatR;
using MiniAzureDevops.ItemTable.Application.Features.Column.Commands.CreateColumn;

namespace MiniAzureDevops.ItemTable.Application.Features.Table.Commands.CreateTable
{
    public class CreateTableCommand : IRequest<CreateTableDto>
    {
        public string Name { get; set; }
    }
}
