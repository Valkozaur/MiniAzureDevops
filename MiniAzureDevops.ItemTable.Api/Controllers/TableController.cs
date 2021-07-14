using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using MediatR;
using System;

using MiniAzureDevops.ItemTable.Application.Features.Table.Commands.CreateTable;
using MiniAzureDevops.ItemTable.Application.Features.Table.Commands.UpdateTable;
using MiniAzureDevops.ItemTable.Application.Features.Table.Queries.GetTableById;

namespace MiniAzureDevops.ItemTable.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly IMediator mediator;

        public TableController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet(Name = "GetTable")]
        public async Task<TableVm> GetTable(GetTableByIdQuery query)
            => await this.mediator.Send(query);

        [HttpPost(Name = "AddTable")]
        public async Task<ActionResult<Guid>> Create(CreateTableCommand createTableCommand)
            => Ok(await this.mediator.Send(createTableCommand));
    }
}
