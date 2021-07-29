using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniAzureDevops.ItemTable.Application.Features.Column.Commands.CreateColumn;
using MiniAzureDevops.ItemTable.Application.Features.Column.Queries.GetColumnsByTableId;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniAzureDevops.ItemTable.Api.Controllers
{
    public class ColumnController : BaseController
    {
        public ColumnController(IMediator mediator) : base(mediator) { }

        [HttpGet(Name = "GetColumns")]
        public async Task<IReadOnlyCollection<ColumnVm>> GetColumns([FromQuery]GetColumnByTableIdQuery getColumnQuery) 
            => await this.mediator.Send(getColumnQuery);

        [HttpPost(Name = "AddColumn")]
        public async Task<CreateColumnCommandResponse> AddColumn([FromBody]CreateColumnCommand createColumnCommand)
            => await this.mediator.Send(createColumnCommand);
    }
}
