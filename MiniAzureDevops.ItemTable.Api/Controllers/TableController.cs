using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using MediatR;
using MongoDB.Bson;

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

        [HttpPost(Name = "AddTable")]
        public async Task<ActionResult<ObjectId>> Create(CreateTableCommand createTableCommand)
            => Ok(await this.mediator.Send(createTableCommand));
        

        [HttpPost(Name = "UpdateTable")]
        public async Task<ActionResult<TableVm>> Update(UpdateTableCommand updateTableCommand)
        {
            await this.mediator.Send(updateTableCommand);
            var query = new GetTableByIdQuery() { Id = updateTableCommand.TableId };

            return Ok(await this.mediator.Send(query));
        }
    }
}
