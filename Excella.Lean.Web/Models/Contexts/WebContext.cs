namespace Excella.Lean.Web.Models.Contexts
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using Breeze.WebApi;

    using Excella.Lean.Core;
    using Excella.Lean.Domain.Shared;
    using Excella.Lean.Domain.Events;

    public abstract class WebContext
    {
        private static readonly object ContextLock = new object();

        private readonly List<KeyMapping> keyMappings = new List<KeyMapping>();

        private readonly IPersonService personService;

        private readonly IEventService eventService;

        protected WebContext(IPersonService personService, IEventService eventService)
        {
            this.personService = personService;
            this.eventService = eventService;
        }

        protected IPersonService PersonService
        {
            get
            {
                return this.personService;
            }
        }

        protected IEventService EventService
        {
            get
            {
                return this.eventService;
            }
        }

        public static object GetDefault(Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }

            return null;
        }

        [SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Justification = "Breeze dependency")]
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
        public List<KeyMapping> SaveChanges(IDictionary<Type, List<EntityInfo>> saveMap)
        {
            lock (ContextLock)
            {
                this.keyMappings.Clear();
                this.SaveRecords(saveMap);

                // ToList effectively copies the _keyMappings so that an incoming SaveChanges call doesn't clear the 
                // keyMappings before the previous version has completed serializing. 
                return this.keyMappings.ToList();
            }
        }

        protected void SaveRecordsHelper(IEnumerable<EntityInfo> items)
        {
            foreach (EntityInfo ei in items)
            {
                if (!(ei.Entity is EntityBase))
                {
                    throw new ArgumentException(string.Format("{0} is not supported, because it doesn't implement IEntity<TKey>"), ei.ToString());
                }

                var record = ei.Entity as EntityBase;

                switch (ei.EntityState)
                {
                    // TODO: code to determine entity's type, and therefore call the right one, needs to go around here somewhere i think? sorry doguhan
                    // TODO: not a trivial change, will fix this
                    case EntityState.Added:
                        this.RepositoryStore.Add(record);
                        this.AddMapping(ei.Entity.GetType(), record.Id);
                        break;
                    case EntityState.Modified:
                        this.RepositoryStore.Update(record);
                        break;
                    case EntityState.Deleted:
                        this.RepositoryStore.Delete(record);
                        break;
                    default:
                        break;
                }
            }

            this.personService.SaveAllChanges();
            this.eventService.SaveAllChanges();
        }

        private void AddMapping<TKey>(Type type, TKey recordId)
        {
            this.keyMappings.Add(new KeyMapping { EntityTypeName = type.FullName, RealValue = recordId, TempValue = recordId });
        }

        private void SaveRecords(IDictionary<Type, List<EntityInfo>> saveMap)
        {
            foreach (Type itemType in saveMap.Keys)
            {
                List<EntityInfo> items;
                if (!saveMap.TryGetValue(itemType, out items))
                {
                    continue;
                }

                this.SaveRecordsHelper(items);
            }
        }
    }
}