namespace Excella.Lean.Domain.Shared.Impl
{
    using Excella.Lean.Core;
    using Excella.Lean.Dal;

    public class ServiceBase : ILeanService
    {
        protected readonly ILeanDatabase Database;

        public ServiceBase(ILeanDatabase database)
        {
            this.Database = database;
        }

        public bool AddUpdate(IEntity entity)
        {
            return this.Database.AddUpdate(entity);
        }

        public bool Remove(IEntity entity)
        {
            return this.Database.Remove(entity);
        }

        public int SaveAllChanges()
        {
            return this.Database.SaveAllChanges();
        }
    }
}
