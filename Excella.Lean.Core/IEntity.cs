namespace Excella.Lean.Core
{
    using System;

    public interface IEntity
    {
        int Id { get; set; }

        string LastUpdateBy { get; set; }

        DateTime LastUpdateDate { get; set; }
    }
}
