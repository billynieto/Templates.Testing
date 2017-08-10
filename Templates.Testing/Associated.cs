using System;

using Templates.Testing.Framework;

namespace Templates.Testing
{
    public abstract class Associated : Relationship, IAssociated
    {
        public Associated(ISpecificationProperty referencingProperty, ISpecificationProperty externallyReferencingProperty)
            : base(referencingProperty, externallyReferencingProperty)
        {
            this.relationshipType = RelationshipType.Associate;
        }

        public Associated(ISpecificationProperty referencingProperty, ISpecificationModel relatedModel)
            : base(referencingProperty, relatedModel)
        {
            this.relationshipType = RelationshipType.Associate;
        }

        public Associated(ISpecificationModel model, ISpecificationProperty externallyReferencingProperty)
            : base(model, externallyReferencingProperty)
        {
            this.relationshipType = RelationshipType.Associate;
        }

        public Associated(ISpecificationModel model, ISpecificationModel relatedModel)
            : base(model, relatedModel)
        {
            this.relationshipType = RelationshipType.Associate;
        }
    }
}
