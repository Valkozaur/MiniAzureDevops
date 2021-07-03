namespace MiniAzureDevops.ItemTable.Persistance.Utillities
{
    public static class CollectionNameHelper
    {
        public static string PluralizeName(string tableName) => $"{tableName}s";
    }
}
