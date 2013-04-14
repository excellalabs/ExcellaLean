namespace Excella.Lean.Core.Models.Shared
{
    using System.ComponentModel.DataAnnotations;

    public class Person : EntityBase
    {
        [StringLength(30)]
        public string FirstName { get; set; }

        [StringLength(30)]
        public string LastName { get; set; }
    }
}
