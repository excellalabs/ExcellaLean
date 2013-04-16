namespace Excella.Lean.Domain.Shared
{
    using Excella.Lean.Core;

    public interface IRepositoryStore
    {
        IEntity Add(IEntity entity);

        IEntity Update(IEntity entity);

        bool Delete(IEntity entity);

        void SaveAllChanges();
    }
}
