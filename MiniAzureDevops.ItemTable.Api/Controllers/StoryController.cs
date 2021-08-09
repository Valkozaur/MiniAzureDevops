using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniAzureDevops.ItemTable.Application.Features.Story.Commands.CreateStory;
using MiniAzureDevops.ItemTable.Application.Features.Story.Queries.GetStoriesByColumnId;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniAzureDevops.ItemTable.Api.Controllers
{
    public class StoryController : BaseController
    {
        public StoryController(IMediator mediator) : base(mediator) {}


        [HttpGet(Name = "Get Stories By Column")]
        public async Task<IReadOnlyCollection<ItemVm>> GetStoriesByColumn([FromQuery]GetItemsByColumnIdQuery request)
            => await this.mediator.Send(request);

        [HttpPost(Name = "Create Story")]
        public async Task<CreateItemCommandResponse> CreateStory([FromBody] CreateItemCommand command)
            => await this.mediator.Send(command);
    }
}
