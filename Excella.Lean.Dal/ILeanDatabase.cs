namespace Excella.Lean.Dal
{
    using System.Linq;

    using Excella.Lean.Core;

    public interface ILeanDatabase
    {
        IQueryable<TEntity> GetAll<TEntity>() where TEntity : class, IEntity;

        bool AddUpdate<TEntity>(TEntity entity) where TEntity : class, IEntity;

        bool Remove<TEntity>(TEntity entity) where TEntity : class, IEntity;

        int SaveAllChanges();
        
        void Dispose(bool disposing);
        
        void Dispose();
    }
}
