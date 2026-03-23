using AutoMapper.EquivalencyExpression;
using System.Data.Linq.Mapping;

namespace AutoMapper.Collection.LinqToSQL
{
    public class GetLinqToSQLPrimaryKeyProperties : IGeneratePropertyMaps
    {
        public IEnumerable<PropertyMap> GeneratePropertyMaps(TypeMap typeMap)
        {
            var propertyMaps = typeMap.PropertyMaps;

            var primaryKeyPropertyMatches = typeMap.DestinationType.GetProperties()
                .Where(IsPrimaryKey)
                .Select(m => propertyMaps.FirstOrDefault(p => p.DestinationMember.Name == m.Name))
                .ToList();

            return primaryKeyPropertyMatches;
        }

        private static bool IsPrimaryKey(PropertyInfo propertyInfo)
        {
            return propertyInfo.GetCustomAttributes(typeof(ColumnAttribute), false)
                .OfType<ColumnAttribute>().Any(ca => ca.IsPrimaryKey);
        }
    }
}