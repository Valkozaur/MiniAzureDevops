using MiniAzureDevops.ItemTable.Application.Responses;

namespace MiniAzureDevops.ItemTable.Application.Features.Column.Commands.CreateColumn
{
    public class CreateColumnCommandResponse : BaseResponse
    { 
        public CreateColumnDto Column { get; set; }
    }
}
