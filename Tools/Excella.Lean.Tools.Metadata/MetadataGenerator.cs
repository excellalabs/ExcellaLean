namespace Excella.Lean.Core.Models
{
    using System;
    using System.Configuration;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using System.IO;

    using Breeze.WebApi;

    using Excella.Lean.Web.Models;

    public class MetadataGenerator
    {
        public const string ConnectionStringKey = "MetadataGeneratorConnectionString";

        public const string JsonLocationKey = "JsonLocation";

        private static string mdfLocation;

        private static string dbName;

        private static MetadataGenerator instance;

        private MetadataProvider provider;

        private MetadataGenerator()
        {
        }

        public static MetadataGenerator Instance
        {
            get
            {
                return instance ?? (instance = new MetadataGenerator());
            }
        }

        public string Metadata
        {
            get
            {
                if (this.provider == null)
                {
                    this.provider = new MetadataProvider();
                }

                return this.provider.Metadata();
            }
        }

        public string MdfLocation
        {
            get
            {
                return mdfLocation ?? (mdfLocation = string.Format("{0}.mdf", Path.Combine(Path.GetTempPath(), this.DbName)));
            }
        }

        public string DbName
        {
            get
            {
                return dbName ?? (dbName = Guid.NewGuid().ToString());
            }
        }

        public string JsonLocation
        {
            get
            {
                return ConfigurationManager.AppSettings[JsonLocationKey];
            }
        }

        internal sealed class MetadataContext : DbContext
        {
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                MetadataModelBuilder.BuildWebModel(modelBuilder);
                base.OnModelCreating(modelBuilder);
            }
        }

        private class MetadataProvider : EFContextProvider<MetadataContext>
        {
            protected override MetadataContext CreateContext()
            {
                MetadataContext context = base.CreateContext();
                var builder = new SqlConnectionStringBuilder(ConfigurationManager.AppSettings[ConnectionStringKey])
                                  {
                                      AttachDBFilename = Instance.MdfLocation,
                                      InitialCatalog = Instance.DbName
                                  };

                context.Database.Connection.ConnectionString = builder.ConnectionString;
                return context;
            }
        }
    }
}