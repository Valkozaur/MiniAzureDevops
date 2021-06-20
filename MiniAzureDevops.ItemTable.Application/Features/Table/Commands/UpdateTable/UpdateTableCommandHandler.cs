using AutoMapper;
using MediatR;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using System.Threading;
using System.Threading.Tasks;

namespace MiniAzureDevops.ItemTable.Application.Features.Table.Commands.UpdateTable
{
    public class UpdateTableCommandHandler : IRequestHandler<UpdateTableCommand, Unit>
    {
        private readonly IMapper mapper;
        private readonly ITableRepository tableRepository;

        public UpdateTableCommandHandler(IMapper mapper, ITableRepository tableRepository)
        {
            this.mapper = mapper;
            this.tableRepository = tableRepository;
        }

        public async Task<Unit> Handle(UpdateTableCommand request, CancellationToken cancellationToken)
        {
            var tableToUpdate = await this.tableRepository.GetByIdAsync(request.TableId);

            this.mapper.Map(request, tableToUpdate, typeof(UpdateTableCommand), typeof(Domain.Entities.Table));

            await this.tableRepository.UpdateAsync(tableToUpdate);

            return Unit.Value;
        }
    }
}
