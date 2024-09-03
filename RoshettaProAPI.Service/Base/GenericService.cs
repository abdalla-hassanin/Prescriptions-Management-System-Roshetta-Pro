using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using RoshettaProAPI.Infrustructure.Base;

namespace RoshettaProAPI.Service.Base
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        protected readonly IUnitOfWork _unitOfWork;

        public GenericService(IUnitOfWork unitOfWork)
        {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        // CRUD Operations
        public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _unitOfWork.Repository<T>().GetByIdAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _unitOfWork.Repository<T>().GetAllAsync(cancellationToken);
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _unitOfWork.Repository<T>().AddAsync(entity, cancellationToken);
            await _unitOfWork.CompleteAsync(cancellationToken);
        }

        public async Task AddMultipleAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            await _unitOfWork.Repository<T>().AddMultipleAsync(entities, cancellationToken);
            await _unitOfWork.CompleteAsync(cancellationToken);
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
           await _unitOfWork.Repository<T>().UpdateAsync(entity, cancellationToken);
            await _unitOfWork.CompleteAsync(cancellationToken);
        }

        public async Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            await _unitOfWork.Repository<T>().UpdateRangeAsync(entities, cancellationToken);
            await _unitOfWork.CompleteAsync(cancellationToken);
        }

        public async Task RemoveAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _unitOfWork.Repository<T>().RemoveAsync(entity, cancellationToken);
            await _unitOfWork.CompleteAsync(cancellationToken);
        }

        public async Task RemoveMultipleAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            await _unitOfWork.Repository<T>().RemoveMultipleAsync(entities, cancellationToken);
            await _unitOfWork.CompleteAsync(cancellationToken);
        }

        // Query Operations

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, CancellationToken cancellationToken = default)
        {
            return await _unitOfWork.Repository<T>().FindAsync(predicate, include, cancellationToken);
        }

        // Boolean Checks
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _unitOfWork.Repository<T>().AnyAsync(predicate, cancellationToken);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _unitOfWork.Repository<T>().CountAsync(predicate, cancellationToken);
        }

        // Pagination and Sorting
        public async Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(Expression<Func<T, bool>> predicate, int pageNumber, int pageSize, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, CancellationToken cancellationToken = default)
        {
            return await _unitOfWork.Repository<T>().GetPagedAsync(predicate, pageNumber, pageSize, orderBy, include, cancellationToken);
        }

        // Specification Pattern
        public async Task<IEnumerable<T>> FindBySpecificationAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
        {
            return await _unitOfWork.Repository<T>().FindBySpecificationAsync(specification, cancellationToken);
        }
    }
}
