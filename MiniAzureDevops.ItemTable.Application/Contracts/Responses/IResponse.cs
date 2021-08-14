namespace MiniAzureDevops.ItemTable.Application.Contracts.Responses
{
    public interface IResponse
    {
        bool Success { get; set; }

        string Message { get; set; }

        List<string> ValidationErrors { get; set; }
    }
}
