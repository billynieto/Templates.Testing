using System;

namespace Templates.Testing.Framework
{
    public interface ISignificantOther : IRelationship
    {
        ISpecificationModel Child { get; }
    }
}
