using AutoMapper;
using MediatR;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;

namespace MiniAzureDevops.ItemTable.Application.Features.Table.Commands.CreateTable
{
    public class CreateTableCommandHandler : IRequestHandler<CreateTableCommand, CreateTableDto>
    {
        private readonly IMapper mapper;
        private readonly ITableRepository tableRepository;

        public CreateTableCommandHandler(IMapper mapper, ITableRepository tableRepository)
        {
            this.mapper = mapper;
            this.tableRepository = tableRepository;
        }

        public async Task<CreateTableDto> Handle(CreateTableCommand request, CancellationToken cancellationToken)
        {
            var table = this.mapper.Map<Domain.Entities.Table>(request);
            await this.tableRepository.AddAsync(table);
            await this.tableRepository.SaveChangesAsync();

            return this.mapper.Map<CreateTableDto>(table);
        }
    }
}
