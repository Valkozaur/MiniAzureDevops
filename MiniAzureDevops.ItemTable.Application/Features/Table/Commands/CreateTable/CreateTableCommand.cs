using MediatR;
using MongoDB.Bson;
using System;

namespace MiniAzureDevops.ItemTable.Application.Features.Table.Commands.CreateTable
{
    public class CreateTableCommand : IRequest<Guid>
    {
        public string Name { get; set; }
    }
}
