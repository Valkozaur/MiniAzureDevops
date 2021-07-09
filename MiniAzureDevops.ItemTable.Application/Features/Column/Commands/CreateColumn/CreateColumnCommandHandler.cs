using AutoMapper;
using MediatR;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using MiniAzureDevops.ItemTable.Application.Extensions;
using System.Threading;
using System.Threading.Tasks;

namespace MiniAzureDevops.ItemTable.Application.Features.Column.Commands.CreateColumn
{
    public class CreateColumnCommandHandler : IRequestHandler<CreateColumnCommand, CreateColumnCommandResponse>
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

        public async Task<CreateColumnCommandResponse> Handle(CreateColumnCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateColumnCommandResponse();

            var validator = new CreateColumnCommandValidator(this.tableRepository);
            var validatonResult = await validator.ValidateAsync(request);

            if(!validatonResult.IsValid)
            {
                response.BuildErrorResponse(validatonResult.Errors);   
            }
            if (response.Success)
            {
                var column = new Domain.Entities.Column() { Name = request.Name, TableId = request.TableId };
                column = await this.columnRepository.AddAsync(column);
                response.Column = this.mapper.Map<CreateColumnDto>(column);
            }

            return response;
        }
    }
}
