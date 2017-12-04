using AutoMapper;

namespace MVCExample.Infrastructure
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IProfileExpression configuration);
    }
}
