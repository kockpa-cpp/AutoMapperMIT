using System;
using Microsoft.Extensions.Logging.Abstractions;

namespace AutoMapper.Collection
{
    public abstract class MappingTestBase
    {
        protected IMapper CreateMapper(Action<IMapperConfigurationExpression> cfg)
        {
            var map = new MapperConfiguration(cfg, new NullLoggerFactory());
            map.CompileMappings();

            var mapper = map.CreateMapper();
            mapper.ConfigurationProvider.AssertConfigurationIsValid();
            return mapper;
        }
    }
}
