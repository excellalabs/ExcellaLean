namespace Excella.Lean.Dal.EntityFramework.Contexts
{
    using System.Data.Entity;
    using System.Linq;

    using Excella.Lean.Core.Models.Shared;

    public partial class LeanDatabase
    {
        public DbSet<Person> Persons { get; set; }

        IQueryable<Person> ILeanDatabase.Persons
        {
            get { return this.Persons; }
        }

    }
}
