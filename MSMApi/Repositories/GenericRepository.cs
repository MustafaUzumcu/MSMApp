using System.Linq.Expressions;

public abstract class GenericRepository<T> : IRepositoryBase<T> where T : class
{
    private readonly ApplicationDbContext _context;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Insert(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public IQueryable<T> GetAll()
    {
        return _context.Set<T>();
    }

    public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression);
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }
}