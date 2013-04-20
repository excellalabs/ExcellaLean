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
    using Excella.Lean.Dal.EntityFramework.Mapping;

    public class LeanDatabase : DbContext, ILeanDatabase
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

        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class, IEntity
        {
            return this.Set<TEntity>();
        }

        public bool AddUpdate<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            if (entity == null)
            {
                throw new ArgumentException("Cannot add a null entity");
            }

            var id = entity.Id;

            if (this.Entry(entity).State == EntityState.Detached)
            {
                var attachedEntity = this.Set(entity.GetType()).Find(id);
                var isFound = attachedEntity != null;

                if (isFound)
                {
                    this.Entry(attachedEntity).CurrentValues.SetValues(entity);
                }
                else
                {
                    var set = this.Set(entity.GetType());
                    set.Add(entity);
                }
            }

            return true;
        }

        public bool Remove<TEntity>(TEntity entity) where TEntity : class, IEntity
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
                return true;
            }

            return false;
        }

        public int SaveAllChanges()
        {
            return this.SaveChanges();
        }

        public new void Dispose(bool disposing)
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

        public new void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EventMap());
            modelBuilder.Configurations.Add(new PersonMap());
            modelBuilder.Configurations.Add(new ReservationRequestMap());
            modelBuilder.Configurations.Add(new ReservationResultMap());
        }
    }
}
