using MediatR;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;

namespace MiniAzureDevops.ItemTable.Application.Features.Table.Commands.DeleteTable
{
    public class DeleteTableCommandHandler : IRequestHandler<DeleteTableCommand, Unit>
    {
        private readonly ITableRepository tableRepository;

        public DeleteTableCommandHandler(ITableRepository tableRepository)
        {
            this.tableRepository = tableRepository;
        }

        public async Task<Unit> Handle(DeleteTableCommand request, CancellationToken cancellationToken)
        {
            var table = await this.tableRepository.GetByIdAsync(request.TableId);
            this.tableRepository.Delete(table);
            
            return Unit.Value;
        }
    }
}
