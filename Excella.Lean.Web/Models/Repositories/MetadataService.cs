namespace Excella.Lean.Web.Models.Repositories
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;

    public class MetadataService
    {
        private const string MetadataFilesPathKey = "MetadataFilesPath";

        private static MetadataService instance;

        private readonly Dictionary<string, string> metadataCache = new Dictionary<string, string>();

        private MetadataService()
        {
        }

        public static MetadataService Instance
        {
            get
            {
                return instance ?? (instance = new MetadataService());
            }
        }

        public string GetMetadata(string metadataFileName)
        {
            if (!this.metadataCache.ContainsKey(metadataFileName))
            {
                this.metadataCache.Add(metadataFileName, this.LoadMetadata(metadataFileName));
            }

            return this.metadataCache[metadataFileName];
        }

        private string LoadMetadata(string metadataFileName)
        {
            var filesPath = ConfigurationManager.AppSettings[MetadataFilesPathKey];

            var serverPath = System.Web.HttpContext.Current.Server.MapPath(filesPath);

            var fileName = string.Format("{0}.json", Path.Combine(serverPath, metadataFileName));

            string toReturn;

            using (var sr = new StreamReader(fileName))
            {
                toReturn = sr.ReadToEnd();
            }

            return toReturn;
        }
    }
}