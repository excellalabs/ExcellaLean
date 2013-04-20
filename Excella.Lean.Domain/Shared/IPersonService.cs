namespace Excella.Lean.Domain.Shared
{
    using System.Linq;

    using Excella.Lean.Core;
    using Excella.Lean.Core.Models.Shared;
    
    public interface IPersonService : ILeanService
    {
        IQueryable<Person> Persons { get; }
    }
}
