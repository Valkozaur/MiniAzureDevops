using AutoMapper;
using MediatR;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;

namespace MiniAzureDevops.ItemTable.Application.Features.Column.Commands.CreateColumn
{
    public class CreateColumnCommandHandler : IRequestHandler<CreateColumnCommand, CreateColumnDto>
    {
        private readonly IMapper mapper;
        private readonly IColumnRepository columnRepository;
        private readonly ITableRepository tableRepository;

        public CreateColumnCommandHandler(IMapper mapper, IColumnRepository columnRepository, ITableRepository tableRepository)
        {
            this.mapper = mapper;
            this.columnRepository = columnRepository;
            this.tableRepository = tableRepository;
        }

        public async Task<CreateColumnDto> Handle(CreateColumnCommand request, CancellationToken cancellationToken)
        {
            var column = new Domain.Entities.Column() { Name = request.Name, TableId = request.TableId };
            await this.columnRepository.AddAsync(column);
            await this.columnRepository.SaveChangesAsync();

            return this.mapper.Map<CreateColumnDto>(column);
        }
    }
}
