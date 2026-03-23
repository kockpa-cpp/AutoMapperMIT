namespace AutoMapper.Extensions.ExpressionMapping
{
    using MemberPaths = IEnumerable<IEnumerable<MemberInfo>>;

    internal static class ReflectionExtensions
    {
        public static object GetMemberValue(this MemberInfo propertyOrField, object target)
            => ReflectionHelper.GetMemberValue(propertyOrField, target);

        public static MemberPaths GetMemberPaths(Type type, string[] membersToExpand) =>
            membersToExpand.Select(m => ReflectionHelper.GetMemberPath(type, m));

        public static MemberPaths GetMemberPaths<TResult>(Expression<Func<TResult, object>>[] membersToExpand) =>
            membersToExpand.Select(expr => MemberVisitor.GetMemberPath(expr));

        public static Type GetMemberType(this MemberInfo memberInfo)
            => ReflectionHelper.GetMemberType(memberInfo);

        public static bool GetIsConstructedGenericType(this Type type) =>
            type.IsConstructedGenericType;
    }
}
