namespace Excella.Lean.Domain.Shared
{
    using System.Linq;
    using Excella.Lean.Core.Models.Shared;
    
    public interface IPersonService
    {
        IQueryable<Person> Persons { get; }

        void SaveAllChanges();
    }
}
