using FluentValidation;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using System.Threading;
using System.Threading.Tasks;

namespace MiniAzureDevops.ItemTable.Application.Features.Column.Commands.DeleteColumn
{
    public class DeleteColumnCommandValidator : AbstractValidator<DeleteColumnCommand>
    {
        private readonly IColumnRepository columnRepository;

        public DeleteColumnCommandValidator(IColumnRepository columnRepository)
        {
            this.columnRepository = columnRepository;

            RuleFor(c => c)
                .MustAsync(ColumnHasNoChildren)
                .WithMessage("Column must not have any children in order to delete it!");

        }

        private async Task<bool> ColumnHasNoChildren(DeleteColumnCommand request, CancellationToken token)
            => !(await this.columnRepository.HasColumnItems(request.ColumnId));
    }
}
