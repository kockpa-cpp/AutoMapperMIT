using System;

namespace AutoMapper.Extensions.ExpressionMapping
{
    public static class ConfigurationHelper
    {
        public static MapperConfiguration GetMapperConfiguration(Action<IMapperConfigurationExpression> configure)
        {
            return new MapperConfiguration(configure);
        }

        public static MapperConfiguration GetMapperConfiguration(MapperConfigurationExpression configurationExpression)
        {
            return new MapperConfiguration(configurationExpression);
        }
    }
}
