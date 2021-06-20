﻿using FluentValidation.Results;
using MiniAzureDevops.ItemTable.Application.Contracts.Responses;
using System.Collections.Generic;

namespace MiniAzureDevops.ItemTable.Application.Extensions
{
    public static class BuildErrorResponseExtension
    {
        public static IResponse BuildErrorResponse(this IResponse response, List<ValidationFailure> errors)
        {
            response.Success = false;
            response.ValidationErrors = new List<string>();
            foreach (var error in errors)
            {
                response.ValidationErrors.Add(error.ErrorMessage);
            }

            return response;
        }
    }
}