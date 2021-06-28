using MediatR;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using System.Threading;
using System.Threading.Tasks;

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
            await this.tableRepository.DeleteAsync(request.TableId);
            
            return Unit.Value;
        }
    }
}
