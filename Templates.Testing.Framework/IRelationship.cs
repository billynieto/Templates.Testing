using System;

namespace Templates.Testing.Framework
{
    public enum RelationshipType
    {
        Associate,
        Child,
        Marriage,
        Parent
    }

    public interface IRelationship
    {
        ISpecificationProperty ExternallyReferencingProperty { get; }
        bool IsRecursive { get; }
        ISpecificationModel Model { get; }
        ISpecificationProperty ReferencingProperty { get; }
        ISpecificationModel RelatedModel { get; }
        RelationshipType Type { get; }
    }
}
