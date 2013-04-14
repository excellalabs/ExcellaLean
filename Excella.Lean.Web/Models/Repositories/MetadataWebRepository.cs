namespace Excella.Lean.Web.Models.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using Breeze.WebApi;

    using Excella.Lean.Web.Models.Contexts;

    public abstract class MetadataWebRepository : ContextProvider
    {
        private readonly string metadataFileName;

        protected MetadataWebRepository(string metadataFileName, IWebContext webContext)
        {
            this.WebContext = webContext;

            this.metadataFileName = metadataFileName;
        }

        private IWebContext WebContext { get; set; }
        
        protected override string BuildJsonMetadata()
        {
            return MetadataService.Instance.GetMetadata(this.metadataFileName);
        }

        [SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Justification = "Breeze dependency")]
        protected override List<KeyMapping> SaveChangesCore(Dictionary<Type, List<EntityInfo>> saveMap)
        {
            return this.WebContext.SaveChanges(saveMap);
        }
    }
}