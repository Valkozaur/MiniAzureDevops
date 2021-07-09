namespace MiniAzureDevops.ItemTable.Persistance.Utillities
{
    public static class CollectionNameHelper
    {
        public static string PluralizeName(string tableName) => tableName.EndsWith('y') ? tableName.Replace("y", "ies") : $"{tableName}s";
    }
}
