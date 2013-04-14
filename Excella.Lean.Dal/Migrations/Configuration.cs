namespace Excella.Lean.Dal.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EntityFramework.Contexts.LeanDatabase>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EntityFramework.Contexts.LeanDatabase context)
        {
        }
    }
}
