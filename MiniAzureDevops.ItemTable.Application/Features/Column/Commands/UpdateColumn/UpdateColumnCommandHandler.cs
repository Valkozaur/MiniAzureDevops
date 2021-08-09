using AutoMapper;
using MediatR;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using System.Threading;
using System.Threading.Tasks;

namespace MiniAzureDevops.ItemTable.Application.Features.Column.Commands.UpdateColumn
{
    public class UpdateColumnCommandHandler : IRequestHandler<UpdateColumnCommand, Unit>
    {
        private readonly IMapper mapper;
        private readonly IColumnRepository columnRepository;
        private readonly ITableRepository tableRepository;

        public UpdateColumnCommandHandler(IMapper mapper, IColumnRepository columnRepository, ITableRepository tableRepository)
        {
            this.mapper = mapper;
            this.columnRepository = columnRepository;
            this.tableRepository = tableRepository;
        }

        public async Task<Unit> Handle(UpdateColumnCommand request, CancellationToken cancellationToken)
        {
            var columnToUpdate = await this.columnRepository.GetByIdAsync(request.ColumnId);

            if (columnToUpdate == null)
                throw new Exceptions.NotFoundException(nameof(Domain.Entities.Column), request.ColumnId);

            var validator = new UpdateColumnCommandValidator(this.tableRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult);

            this.mapper.Map(request, columnToUpdate, typeof(UpdateColumnCommand), typeof(Domain.Entities.Column));

            this.columnRepository.Update(columnToUpdate);

            return Unit.Value;
        }
    }
}
