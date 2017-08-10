using System;
using System.Collections.Generic;

using Templates.Testing.Framework;

namespace Templates.Testing
{
    public abstract class Child : Relationship, IChild
    {
        public Child(ISpecificationProperty referencingProperty, ISpecificationProperty externallyReferencingProperty)
            : base(referencingProperty, externallyReferencingProperty)
        {
            this.relationshipType = RelationshipType.Child;
        }

        public Child(ISpecificationProperty referencingProperty, ISpecificationModel relatedModel)
            : base(referencingProperty, relatedModel)
        {
            this.relationshipType = RelationshipType.Child; 
        }

        public Child(ISpecificationModel model, ISpecificationProperty externallyReferencingProperty)
            : base(model, externallyReferencingProperty)
        {
            this.relationshipType = RelationshipType.Child;
        }

        public Child(ISpecificationModel model, ISpecificationModel relatedModel)
            : base(model, relatedModel)
        {
            this.relationshipType = RelationshipType.Child;
        }
    }
}
