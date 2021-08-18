using Microsoft.AspNetCore.Mvc;

using MediatR;

using MiniAzureDevops.ItemTable.Application.Features.Table.Commands.CreateTable;
using MiniAzureDevops.ItemTable.Application.Features.Table.Queries.GetTableById;
using MiniAzureDevops.ItemTable.Application.Features.Column.Queries.GetColumnsByTableId;

namespace MiniAzureDevops.ItemTable.Api.Controllers
{
    public class TablesController : BaseController
    {
        public TablesController(IMediator mediator) : base(mediator) { }


        [HttpGet("{id}")]
        public async Task<GetTableByIdVm> GetTable([FromBody] GetTableByIdQuery query)
            => await this.mediator.Send(query);

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTableCommand createTableCommand)
            => Created($"", await this.mediator.Send(createTableCommand));

        [HttpGet("{id}/columns")]
        public async Task<IActionResult> GetTableColumns([FromRoute] GetColumnByTableIdQuery query)
            => Ok(await this.mediator.Send(query));

    }
}
