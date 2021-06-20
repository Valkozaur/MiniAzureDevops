using FluentValidation;

namespace MiniAzureDevops.ItemTable.Application.Features.Table.Commands.UpdateTable
{
    public class UpdateTableCommandValidator : AbstractValidator<UpdateTableCommand>
    {
        public UpdateTableCommandValidator()
        {
            RuleFor(t => t.Name)
                .NotEmpty().WithMessage("TableName is required!")
                .NotNull()
                .MaximumLength(100).WithMessage("TableName must not exceed 100 characters!");
        }
    }
}
