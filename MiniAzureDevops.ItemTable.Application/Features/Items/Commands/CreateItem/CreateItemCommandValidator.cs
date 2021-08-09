using FluentValidation;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;

namespace MiniAzureDevops.ItemTable.Application.Features.Story.Commands.CreateStory
{
    public class CreateItemCommandValidator : AbstractValidator<CreateItemCommand>
    {
        private readonly ITableRepository tableRepositroy;

        public CreateItemCommandValidator(ITableRepository tableRepositroy)
        {
            this.tableRepositroy = tableRepositroy;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name must be defined!")
                .NotNull()
                .MaximumLength(50).WithMessage("Name must be less than 50 characters!");
        }
    }
}

