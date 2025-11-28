using System;
using AutoMapper.EquivalencyExpression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;

namespace AutoMapper.Collection.EntityFrameworkCore.Tests
{
    public class EntityFrameworkCoreUsingCtorTests : EntityFramworkCoreTestsBase
    {
        public EntityFrameworkCoreUsingCtorTests()
        {
            mapper = new Mapper(new MapperConfiguration(x =>
            {
                x.AddCollectionMappers();
                x.CreateMap<ThingDto, Thing>().ReverseMap();
                x.UseEntityFrameworkCoreModel<DB>();
            }, new NullLoggerFactory()));

            db = new DB();
        }

        public class DB : DBContextBase
        {
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseInMemoryDatabase("EfTestDatabase" + Guid.NewGuid());
                base.OnConfiguring(optionsBuilder);
            }
        }
    }
}
