namespace Excella.Lean.Domain.Shared.Impl
{
    using System.Linq;

    using Excella.Lean.Core.Models.Shared;
    using Excella.Lean.Dal;

    public class PersonService : ServiceBase, IPersonService
    {
        public PersonService(ILeanDatabase database)
            : base(database)
        {
        }

        public IQueryable<Person> Persons
        {
            get
            {
                return this.Database.GetAll<Person>();
            }
        }
    }
}
