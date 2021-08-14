namespace MiniAzureDevops.ItemTable.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public ValidationException(string errors)
        {
            this.ValidationErrors = errors;
        }

        public string ValidationErrors { get; set; }
    }
}
