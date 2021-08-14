using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniAzureDevops.ItemTable.Application.Features.Column.Commands.CreateColumn;
using MiniAzureDevops.ItemTable.Application.Features.Column.Queries.GetColumnsByTableId;

namespace MiniAzureDevops.ItemTable.Api.Controllers
{
    public class ColumnController : BaseController
    {
        public ColumnController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IReadOnlyCollection<ColumnVm>> GetColumns([FromQuery]GetColumnByTableIdQuery getColumnQuery) 
            => await this.mediator.Send(getColumnQuery);

        [HttpPost(Name = "AddColumn")]
        public async Task<CreateColumnCommandResponse> AddColumn([FromBody]CreateColumnCommand createColumnCommand)
            => await this.mediator.Send(createColumnCommand);
    }
}
