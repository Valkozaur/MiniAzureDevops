using MiniAzureDevops.ItemTable.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MiniAzureDevops.ItemTable.Application.Features.Table.Queries.GetTableById
{
    public class TableVm
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public HashSet<Column> Columns { get; set; } = new HashSet<Column>();
    }
}