using MediatR;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
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
            var column = this.columnRepository.GetByIdAsync(request.ColumnId);
            if (column == null)
                throw new Exceptions.NotFoundException(nameof(Domain.Entities.Column), request.ColumnId);

            var validator = new DeleteColumnCommandValidator(this.columnRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult);

            await this.columnRepository.DeleteAsync(request.ColumnId);

            return Unit.Value;
        }
    }
}
