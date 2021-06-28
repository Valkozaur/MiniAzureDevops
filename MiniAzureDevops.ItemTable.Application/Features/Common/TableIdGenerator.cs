using System;

namespace MiniAzureDevops.ItemTable.Application.Features.Common
{
    public static class TableIdGenerator
    {
        public static int GetRandomTableId()
        {
            var rand = new Random();
            return rand.Next(100_000, 1_000_000);
        }
    }
}
