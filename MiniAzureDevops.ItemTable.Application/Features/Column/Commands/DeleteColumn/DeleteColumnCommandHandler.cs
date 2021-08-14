using MediatR;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using System.Linq;
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
            var column = await this.columnRepository.GetByIdAsync(request.ColumnId);
            if (column == null)
                throw new Exceptions.NotFoundException(nameof(Domain.Entities.Column), request.ColumnId);

            this.columnRepository.Delete(column);

            return Unit.Value;
        }
    }
}
