using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniAzureDevops.ItemTable.Application.Features.Column.Commands.CreateColumn;

namespace MiniAzureDevops.ItemTable.Api.Controllers
{
    public class ColumnController : BaseController
    {
        public ColumnController(IMediator mediator) : base(mediator) { }

        [HttpPost]
        public async Task<IActionResult> AddColumn([FromBody]CreateColumnCommand createColumnCommand)
            => this.Created("", await this.mediator.Send(createColumnCommand));
    }
}
