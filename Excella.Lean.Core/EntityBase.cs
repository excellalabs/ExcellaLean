namespace Excella.Lean.Core
{
    using System;

    public abstract class EntityBase : IEntity
    {
        public virtual int Id { get; set; }

        public virtual string LastUpdateBy { get; set; }

        public virtual DateTime LastUpdateDate { get; set; }
    }
}
