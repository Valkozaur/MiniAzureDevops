using FluentValidation;

namespace MiniAzureDevops.ItemTable.Application.Features.Project.Queries.GetProjectById
{
    public class GetProjectByIdQueryValidator : AbstractValidator<GetProjectByIdQuery>
    {
        public GetProjectByIdQueryValidator()
        {
            RuleFor(x => x.ProjectId)
                .NotEmpty().WithMessage("Guid cannot be null!");
        }
    }
}
