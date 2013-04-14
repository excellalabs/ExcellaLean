namespace Excella.Lean.Dal.EntityFramework.Contexts
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    using Excella.Lean.Core;


    public partial class LeanDatabase : DbContext, ILeanDatabase
    {
        private bool disposedValue;

        static LeanDatabase()
        {
            Database.SetInitializer<LeanDatabase>(null);
        }

        public LeanDatabase()
            : base("Name=LeanEntities")
        {
            // This is required to keep runtime types consistent with Client Metadata
            //this.Configuration.ProxyCreationEnabled = false;
        }

        public IQueryable<TEntity> Select<TEntity>() where TEntity : class, IEntity
        {
            return this.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class, IEntity
        {
            return this.Set<TEntity>();
        }

        public IQueryable<TEntity> Where<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity
        {
            return this.Set<TEntity>().Where(predicate);
        }

        public TEntity GetSingle<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity
        {
            return this.Set<TEntity>().SingleOrDefault(predicate);
        }

        public TEntity GetFirst<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity
        {
            return this.Set<TEntity>().First(predicate);
        }
        
        public void Save<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            if (entity == null)
            {
                throw new ArgumentException("Cannot add a null entity");
            }

            try
            {
                var id = entity.Id;

                if (this.Entry(entity).State == EntityState.Detached)
                {
                    var attachedEntity = this.Set(entity.GetType()).Find(id);
                    var isFound = attachedEntity != null;

                    if (isFound)
                    {
                        this.Entry(attachedEntity).CurrentValues.SetValues(entity);
                    }

                    if (!isFound)
                    {
                        var set = this.Set(entity.GetType());
                        set.Add(entity);
                    }
                }

                this.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }

                throw;
            }
        }

        public void Save<TEntity>(IList<TEntity> entities) where TEntity : class, IEntity
        {
            if (entities == null || !entities.Any())
            {
                throw new ArgumentException("Cannot add a null entity");
            }

            try
            {
                ICollection<TEntity> collection = new Collection<TEntity>(entities);
                //this.HierarchicalSaveCollection(collection);
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }

                throw;
            }
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            if (entity == null)
            {
                throw new ArgumentException("Cannot delete a null entity", "entity");
            }

            var set = this.Set<TEntity>();
            var attachedEntity = set.Find(entity.Id);

            if (attachedEntity != null && this.Entry(attachedEntity).State != EntityState.Deleted)
            {
                set.Remove(attachedEntity);
            }
            else
            {
                throw new ArgumentException("Could not delete entity because the Id could not be found or the entity does not exist.", "entity");
            }

            this.SaveChanges();
        }

        public void Attach<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            if (entity == null)
            {
                throw new ArgumentException("Cannot attach a null entity");
            }

            this.Set<TEntity>().Attach(entity);
        }

        public void Add(IEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Cannot add a null entity");
            }

            var set = this.Set(entity.GetType());
            set.Add(entity);
        }

        public void Update(IEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Cannot add a null entity");
            }

            var id = entity.Id;

            if (this.Entry(entity).State == EntityState.Detached)
            {
                var attachedEntity = this.Set(entity.GetType()).Find(id);
                this.Entry(attachedEntity).CurrentValues.SetValues(entity);
            }
        }

        public void SaveAllChanges()
        {
            this.SaveChanges();
        }

        public void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    // dispose managed state here if required
                }

                // dispose unmanaged objects and set large fields to null
            }

            this.disposedValue = true;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            //modelBuilder.Configurations.Add(new EventMap());

        }
    }
}
