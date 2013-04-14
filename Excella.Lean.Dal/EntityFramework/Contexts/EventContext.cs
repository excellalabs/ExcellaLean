namespace Excella.Lean.Dal.EntityFramework.Contexts
{
    using System.Data.Entity;
    using System.Linq;

    using Excella.Lean.Core.Models.Events;

    public partial class LeanDatabase
    {
        public DbSet<Event> Events { get; set; }

        IQueryable<Event> ILeanDatabase.Events
        {
            get { return this.Events; }
        }
    }
}
