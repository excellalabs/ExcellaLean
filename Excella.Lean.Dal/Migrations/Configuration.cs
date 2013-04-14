namespace Excella.Lean.Dal.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<EntityFramework.Contexts.LeanDatabase>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EntityFramework.Contexts.LeanDatabase context)
        {
            //  This method will be called after migrating to the latest version.

        }
    }
}
