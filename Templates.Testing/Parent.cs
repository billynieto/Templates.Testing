using System;

using Templates.Testing.Framework;

namespace Templates.Testing
{
    public abstract class Parent : Relationship, IParent
    {
        public Parent(ISpecificationProperty referencingProperty, ISpecificationProperty externallyReferencingProperty)
            : base(referencingProperty, externallyReferencingProperty)
        {
            this.relationshipType = Framework.RelationshipType.Parent;
        }

        public Parent(ISpecificationProperty referencingProperty, ISpecificationModel relatedModel)
            : base(referencingProperty, relatedModel)
        {
            this.relationshipType = Framework.RelationshipType.Parent;
        }

        public Parent(ISpecificationModel model, ISpecificationProperty externallyReferencingProperty)
            : base(model, externallyReferencingProperty)
        {
            this.relationshipType = Framework.RelationshipType.Parent;
        }

        public Parent(ISpecificationModel model, ISpecificationModel relatedModel)
            : base(model, relatedModel)
        {
            this.relationshipType = Framework.RelationshipType.Parent;
        }
    }
}
