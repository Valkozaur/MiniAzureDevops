using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniAzureDevops.ItemTable.Application.Features.Story.Commands.CreateStory;

namespace MiniAzureDevops.ItemTable.Api.Controllers
{
    public class ItemsController : BaseController
    {
        public ItemsController(IMediator mediator) : base(mediator) {}

        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] CreateItemCommand command)
            => Created("", await this.mediator.Send(command));
    }
}
