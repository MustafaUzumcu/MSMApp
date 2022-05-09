using System.Linq.Expressions;

public interface IRepositoryBase<T>
{
    IQueryable<T> GetAll();
    IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression);
    void Insert(T entity);
    void Update(T entity);
}