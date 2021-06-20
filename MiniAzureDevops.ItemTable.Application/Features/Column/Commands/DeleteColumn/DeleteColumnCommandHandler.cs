using MediatR;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using MiniAzureDevops.ItemTable.Application.Extensions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MiniAzureDevops.ItemTable.Application.Features.Column.Commands.DeleteColumn
{
    public class DeleteColumnCommandHandler : IRequestHandler<DeleteColumnCommand, Unit>
    {
        private readonly IColumnRepository columnRepository;

        public DeleteColumnCommandHandler(IColumnRepository columnRepository)
        {
            this.columnRepository = columnRepository;
        }

        public async Task<Unit> Handle(DeleteColumnCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteColumnCommandResponse();

            var validator = new DeleteColumnCommandValidator(this.columnRepository);
            var validatonResult = await validator.ValidateAsync(request);

            if (!validatonResult.IsValid)
            {
                response.BuildErrorResponse(validatonResult.Errors);
            }


            var column = this.columnRepository.GetByIdAsync(request.ColumnId);

            

            column.
        }
    }
}
