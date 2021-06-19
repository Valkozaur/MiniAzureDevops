using AutoMapper;

namespace MiniAzureDevops.ItemTable.Application.Common.Extensions.Mapping
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IProfileExpression configuration);
    }
}
