namespace Excella.Lean.Dal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Excella.Lean.Core;
    using Excella.Lean.Core.Models.Events;
    using Excella.Lean.Core.Models.Shared;

    public interface ILeanDatabase
    {
        // Reservation
        IQueryable<ReservationResult> ReservationResults { get; }

        IQueryable<ReservationRequest> ReservationRequests { get; }

        // Person
        IQueryable<Person> Persons { get; }

        // Event
        IQueryable<Event> Events { get; }

        // Global 
        IQueryable<TEntity> Select<TEntity>() where TEntity : class, IEntity;

        IQueryable<TEntity> GetAll<TEntity>() where TEntity : class, IEntity;

        IQueryable<TEntity> Where<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity;

        TEntity GetSingle<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity;

        TEntity GetFirst<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity;

        void Save<TEntity>(TEntity entity) where TEntity : class, IEntity;

        void Save<TEntity>(IList<TEntity> entity) where TEntity : class, IEntity;

        void Delete<TEntity>(TEntity entity) where TEntity : class, IEntity;

        void Attach<TEntity>(TEntity entity) where TEntity : class, IEntity;

        void Add(IEntity entity);

        void Update(IEntity entity);

        void SaveAllChanges();
        
        void Dispose(bool disposing);
        
        void Dispose();
    }
}
