using AutoMapper;
using MediatR;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MiniAzureDevops.ItemTable.Application.Features.Table.Commands.CreateTable
{
    public class CreateTableCommandHandler : IRequestHandler<CreateTableCommand, Unit>
    {
        private readonly IMapper mapper;
        private readonly ITableRepository tableRepository;

        public CreateTableCommandHandler(IMapper mapper, ITableRepository tableRepository)
        {
            this.mapper = mapper;
            this.tableRepository = tableRepository;
        }

        public async Task<Unit> Handle(CreateTableCommand request, CancellationToken cancellationToken)
        {
            var table = this.mapper.Map<Domain.Entities.Table>(request);
            await this.tableRepository.AddAsync(table);

            return Unit.Value;
        }
    }
}
