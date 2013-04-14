namespace Excella.Lean.Web.Models.Contexts
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Diagnostics.CodeAnalysis;

    using Breeze.WebApi;

    public interface IWebContext
    {
        [SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Justification = "Breeze dependency")]
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
        List<KeyMapping> SaveChanges(IDictionary<Type, List<EntityInfo>> saveMap);
    }
}
