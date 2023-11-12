
using DataLayer.IRepository;
using System.Linq.Expressions;

namespace DataLayer.Repository
{
    public class RepositoryBase<TEntity>
         : IRepositoryBase<TEntity> where TEntity : class
    {
        #region Variables

        public readonly DataBaseAppContext _context;

        #endregion

        #region Constructor

        public RepositoryBase(DataBaseAppContext context)
        {
            _context = context;
        }

        #endregion

        #region Public Methods

        /// <summary>  
        /// Adds the specified entity.  
        /// </summary>  
        /// <param name="entity">The entity.</param>  
        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        /// <summary>  
        /// Adds the range.  
        /// </summary>  
        /// <param name="entities">The entities.</param>  
        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
            _context.SaveChanges();
        }

        /// <summary>  
        /// Finds the specified predicate.  
        /// </summary>  
        /// <param name="predicate">The predicate.</param>  
        /// <returns></returns>  
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        /// <summary>  
        /// Singles the or default.  
        /// </summary>  
        /// <param name="predicate">The predicate.</param>  
        /// <returns></returns>  
        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = _context.Set<TEntity>().Where(predicate).SingleOrDefault();
            return entity ?? throw new(nameof(entity));
        }

        /// <summary>  
        /// First the or default.  
        /// </summary>  
        /// <returns></returns>  
        public TEntity FirstOrDefault()
        {
            var entity =  _context.Set<TEntity>().SingleOrDefault();
            return entity ?? throw new (nameof(entity));
        }

        /// <summary>  
        /// Gets the specified identifier.  
        /// </summary>  
        /// <param name="id">The identifier.</param>  
        /// <returns></returns>  
        public TEntity Get(int id)
        {
            var entity =  _context.Set<TEntity>().Find(id);
            return entity ?? throw new(nameof(entity));
        }

        /// <summary>  
        /// Gets the specified identifier async.  
        /// </summary>  
        /// <param name="id">The identifier.</param>  
        /// <returns></returns> 
        public async Task<TEntity> GetAsync(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            return entity ?? throw new(nameof(entity));
        }

        /// <summary>  
        /// Gets all.  
        /// </summary>  
        /// <returns></returns>  
        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        /// <summary>  
        /// Removes the specified entity.  
        /// </summary>  
        /// <param name="entity">The entity.</param>  
        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        /// <summary>  
        /// Removes the range.  
        /// </summary>  
        /// <param name="entities">The entities.</param>  
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
            _context.SaveChanges();
        }

        /// <summary>
        /// Updates the specified entity.  
        /// </summary>
        /// <param name="entity"></param>
        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Updates the range.  
        /// </summary>
        /// <param name="entities"></param>
        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().UpdateRange(entities);
            _context.SaveChanges();
        }
        #endregion


    }
}
