namespace AutoMapper.EquivalencyExpression
{
    public interface IGeneratePropertyMaps
    {
        IEnumerable<PropertyMap> GeneratePropertyMaps(TypeMap typeMap);
    }
}