using FluentValidation;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using System.Threading;
using System.Threading.Tasks;

namespace MiniAzureDevops.ItemTable.Application.Features.Story.Commands.CreateStory
{
    public class CreateStoryCommandValidator : AbstractValidator<CreateStoryCommand>
    {
        private readonly ITableRepository tableRepositroy;

        public CreateStoryCommandValidator(ITableRepository tableRepositroy)
        {
            this.tableRepositroy = tableRepositroy;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name must be defined!")
                .NotNull()
                .MaximumLength(50).WithMessage("Name must be less than 50 characters!");

            RuleFor(x => x)
                .MustAsync(IsTableIdUnique)
                .WithErrorCode("NotTableUniqueId");
        }

        private async Task<bool> IsTableIdUnique(CreateStoryCommand request, CancellationToken token)
            => await this.tableRepositroy.IsTableIdUnique(request.TableId, request.ColumnId);
    }
}
