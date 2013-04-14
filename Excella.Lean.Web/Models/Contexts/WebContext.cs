namespace Excella.Lean.Web.Models.Contexts
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using Breeze.WebApi;

    using Excella.Lean.Core;
    using Excella.Lean.Domain.Core;

    public abstract class WebContext
    {
        private static readonly object ContextLock = new object();

        private readonly List<KeyMapping> keyMappings = new List<KeyMapping>();

        private readonly IRepositoryStore repositoryStore;

        protected WebContext(IRepositoryStore repositoryStore)
        {
            this.repositoryStore = repositoryStore;
        }

        protected IRepositoryStore RepositoryStore
        {
            get
            {
                return this.repositoryStore;
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

            this.RepositoryStore.SaveAllChanges();
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