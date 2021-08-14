namespace MiniAzureDevops.ItemTable.Application.Features.Column.Commands.CreateColumn
{
    public class CreateColumnDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid TableId { get; set; }
    }
}