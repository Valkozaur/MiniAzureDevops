using FluentValidation;

namespace MiniAzureDevops.ItemTable.Application.Features.Table.Commands.CreateTable
{
    public class CreateTableCommandValidator : AbstractValidator<CreateTableCommand>
    {
        public CreateTableCommandValidator()
        {
            RuleFor(t => t.Name)
                .NotEmpty().WithMessage("TableName is required!")
                .NotNull()
                .MaximumLength(100).WithMessage("TableName must not exceed 100 characters!");

            //ensure column is unuqiue.
        }        
    }
}
