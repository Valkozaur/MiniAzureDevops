using FluentValidation;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using MiniAzureDevops.ItemTable.Application.Features.Column.Commands.CreateColumn;
using System.Threading;
using System.Threading.Tasks;

namespace MiniAzureDevops.ItemTable.Application.Features.Column.Commands.UpdateColumn
{
    public class UpdateColumnCommandValidator : AbstractValidator<UpdateColumnCommand>
    {
        private readonly ITableRepository tableRepository;

        public UpdateColumnCommandValidator(ITableRepository tableRepository)
        {
            this.tableRepository = tableRepository;

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Column is required!")
                .NotNull()
                .MaximumLength(50).WithMessage("Column must not exceed 50 characters!");

            RuleFor(e => e)
                .MustAsync(ColumnNameMustBeUniqueInTable)
                .WithMessage("Column name must be unique in the table!");
        }

        private async Task<bool> ColumnNameMustBeUniqueInTable(UpdateColumnCommand request, CancellationToken token)
            => await this.tableRepository.ColumnNameIsUnique(request.TableId, request.Name);
    }
}