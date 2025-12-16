using System.Linq.Expressions;
namespace AssiT.Application.utils
{
    public static class PredicateBuilder
    {
        public static Expression<Func<T, bool>> True<T>() => x => true;

        public static Expression<Func<T, bool>> AndIf<T>(
            this Expression<Func<T, bool>> expression,
            bool condition,
            Expression<Func<T, bool>> predicate)
        {
            if (!condition)
                return expression;

            var parameter = expression.Parameters[0];

            var visitor = new ReplaceExpressionVisitor(
                predicate.Parameters[0],
                parameter);

            var body = Expression.AndAlso(
                expression.Body,
                visitor.Visit(predicate.Body)!);

            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }
    }
}
