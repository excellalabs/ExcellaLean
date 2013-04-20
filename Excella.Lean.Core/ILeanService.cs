namespace Excella.Lean.Core
{
    public interface ILeanService
    {
        bool AddUpdate(IEntity entity);

        bool Remove(IEntity entity);

        int SaveAllChanges();
    }
}
