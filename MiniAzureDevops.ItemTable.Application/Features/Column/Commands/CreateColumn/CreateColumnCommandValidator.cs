using FluentValidation;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;

namespace MiniAzureDevops.ItemTable.Application.Features.Column.Commands.CreateColumn
{
    public class CreateColumnCommandValidator : AbstractValidator<CreateColumnCommand>
    {
        private readonly ITableRepository tableRepository;

        public CreateColumnCommandValidator(ITableRepository tableRepository)
        {
            this.tableRepository = tableRepository;

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Column is required!")
                .NotNull()
                .MaximumLength(50).WithMessage("Column name must not exceed 50 characters!");

            RuleFor(e => e)
                .MustAsync(ColumnNameMustBeUniqueInTable)
                .WithMessage("Column name must be unique in the table!");
        }

        private async Task<bool> ColumnNameMustBeUniqueInTable(CreateColumnCommand request, CancellationToken token)
            => !await this.tableRepository.ColumnNameIsUnique(request.TableId, request.Name);
    }
}
