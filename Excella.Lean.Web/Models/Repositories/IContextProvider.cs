namespace Excella.Lean.Web.Models.Contexts
{
    using Breeze.WebApi;

    public interface IContextProvider
    {
        IKeyGenerator KeyGenerator { get; set; }
        
        string Metadata();
        
        SaveResult SaveChanges(Newtonsoft.Json.Linq.JObject saveBundle);
    }
}
