﻿using MiniAzureDevops.ItemTable.Application.Contracts.Responses;
using System.Collections.Generic;

namespace MiniAzureDevops.ItemTable.Application.Responses
{
    public class BaseResponse : IResponse
    {
        public BaseResponse()
        {
            Success = true;
        }
        public BaseResponse(string message = null)
        {
            Success = true;
            Message = message;
        }

        public BaseResponse(string message, bool success)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }

        public string Message { get; set; }

        public List<string> ValidationErrors { get; set; }
    }
}
