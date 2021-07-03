using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniAzureDevops.ItemTable.Application.Features.Table.Commands.CreateTable;
using MongoDB.Bson;
using System.Threading.Tasks;

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
        {
            var id = await this.mediator.Send(createTableCommand);
            return Ok(id);
        }
    }
}
