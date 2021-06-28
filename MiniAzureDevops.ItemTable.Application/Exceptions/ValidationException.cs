using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace MiniAzureDevops.ItemTable.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public ValidationException(ValidationResult validationResult)
        {
            ValidationErrors = new List<string>();

            foreach (var error in validationResult.Errors)
            {
                ValidationErrors.Add(error.ErrorMessage);
            }
        }

        public List<string> ValidationErrors { get; set; }
    }
}
