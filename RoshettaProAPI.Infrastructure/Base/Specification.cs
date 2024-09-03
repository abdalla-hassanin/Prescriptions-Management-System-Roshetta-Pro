using System.Linq.Expressions;

namespace RoshettaProAPI.Infrustructure.Base
{
    public class Specification<T> : ISpecification<T>
    {
        public Specification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; }

        public Func<IQueryable<T>, IQueryable<T>> Include { get; private set; }

        public Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy { get; private set; }

        public int? Skip { get; private set; }
        public int? Take { get; private set; }

        public Specification<T> AddInclude(Func<IQueryable<T>, IQueryable<T>> includeExpression)
        {
            Include = includeExpression;
            return this;
        }

        public Specification<T> ApplyOrderBy(Func<IQueryable<T>, IOrderedQueryable<T>> orderByExpression)
        {
            OrderBy = orderByExpression;
            return this;
        }

        public Specification<T> ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            return this;
        }
    }
}