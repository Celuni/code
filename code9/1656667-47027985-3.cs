    public static class QueryableExtensions
    {
        public static IQueryable<T> WhereAny<T>(this IQueryable<T> source, IEnumerable<Expression<Func<T, bool>>> predicates)
        {
            if (predicates == null || !predicates.Any()) return source;
            var predicate = predicates.Aggregate((a, b) => Expression.Lambda<Func<T, bool>>(
                Expression.Or(a.Body, b.Body.ReplaceParameter(b.Parameters[0], a.Parameters[0])),
                a.Parameters[0]));
            return source.Where(predicate);
        }
    }
    public static class ExpressionUtils
    {
        public static Expression ReplaceParameter(this Expression expression, ParameterExpression source, Expression target)
        {
            return new ParameterReplacer { Source = source, Target = target }.Visit(expression);
        }
        class ParameterReplacer : ExpressionVisitor
        {
            public ParameterExpression Source;
            public Expression Target;
            protected override Expression VisitParameter(ParameterExpression node)
            {
                return node == Source ? Target : base.VisitParameter(node);
            }
        }
    }
