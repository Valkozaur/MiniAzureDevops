using AutoMapper;

namespace MiniAzureDevops.ItemTable.Application.Mapping
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IProfileExpression configuration);
    }
}
