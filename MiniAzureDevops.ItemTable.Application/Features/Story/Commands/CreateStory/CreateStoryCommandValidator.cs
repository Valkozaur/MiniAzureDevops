using FluentValidation;

namespace MiniAzureDevops.ItemTable.Application.Features.Story.Commands.CreateStory
{
    public class CreateStoryCommandValidator : AbstractValidator<CreateStoryCommand>
    {
        public CreateStoryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name must be defined!")
                .NotNull()
                .MaximumLength(50).WithMessage("Name must be less than 50 characters!")
        }
    }
}
