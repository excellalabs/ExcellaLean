namespace Excella.Lean.Domain.Shared.Impl
{
    using System.Linq;

    using Excella.Lean.Core.Models.Events;
    using Excella.Lean.Dal;
    using Excella.Lean.Core.Models.Shared;

    public class PersonService
    {
        private readonly ILeanDatabase database;

        public PersonService(ILeanDatabase database)
        {
            this.database = database;
        }

        public IQueryable<Person> Persons
        {
            get
            {
                return this.database.Persons;
            }
        }

        public void SaveAllChanges()
        {
            this.database.SaveAllChanges();
        }
    }
}
