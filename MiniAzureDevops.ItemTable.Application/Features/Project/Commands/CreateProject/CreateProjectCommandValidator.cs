using FluentValidation;

namespace MiniAzureDevops.ItemTable.Application.Features.Project.Commands.CreateProject
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().NotNull().WithMessage("Project cannot be created without a name.")
                .MaximumLength(100).WithMessage("Project name must not exceed 50 characters!");
        }
    }
}
