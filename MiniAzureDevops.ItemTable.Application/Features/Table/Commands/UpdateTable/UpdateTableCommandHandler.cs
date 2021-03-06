using AutoMapper;
using MediatR;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;

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

            this.tableRepository.Update(tableToUpdate);

            return Unit.Value;
        }
    }
}
