using FluentValidation;

namespace MiniAzureDevops.ItemTable.Application.Features.Story.Commands.UpdateStory
{
    public class UpdateStoryCommandValidator : AbstractValidator<UpdateItemCommand>
    {
        public UpdateStoryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name must be defined!")
                .NotNull()
                .MaximumLength(50).WithMessage("Name must be less than 50 characters!");
        }
    }
}
