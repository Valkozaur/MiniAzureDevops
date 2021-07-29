using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using MediatR;
using System;

using MiniAzureDevops.ItemTable.Application.Features.Table.Commands.CreateTable;
using MiniAzureDevops.ItemTable.Application.Features.Table.Commands.UpdateTable;
using MiniAzureDevops.ItemTable.Application.Features.Table.Queries.GetTableById;

namespace MiniAzureDevops.ItemTable.Api.Controllers
{
    public class TableController : BaseController
    {
        public TableController(IMediator mediator) : base(mediator) { }


        [HttpGet(Name = "GetTable")]
        public async Task<TableVm> GetTable([FromQuery]GetTableByIdQuery query)
            => await this.mediator.Send(query);

        [HttpPost(Name = "AddTable")]
        public async Task<ActionResult<Guid>> Create([FromBody]CreateTableCommand createTableCommand)
            => Ok(await this.mediator.Send(createTableCommand));
    }
}
