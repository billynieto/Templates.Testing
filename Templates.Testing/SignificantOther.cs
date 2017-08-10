using System;
using System.Collections.Generic;

using Templates.Testing.Framework;

namespace Templates.Testing
{
    public abstract class SignificantOther : Relationship, ISignificantOther
    {
        protected ISpecificationModel child;
        
        public ISpecificationModel Child { get { return this.child; } }

        public SignificantOther(ISpecificationProperty referencingProperty, ISpecificationProperty externallyReferencingProperty, ISpecificationModel child)
            : base(referencingProperty, externallyReferencingProperty)
        {
            this.relationshipType = RelationshipType.Marriage;

            this.child = child;
        }

        public SignificantOther(ISpecificationProperty referencingProperty, ISpecificationModel relatedModel, ISpecificationModel child)
            : base(referencingProperty, relatedModel)
        {
            this.relationshipType = RelationshipType.Marriage;

            this.child = child;
        }

        public SignificantOther(ISpecificationModel model, ISpecificationProperty externallyReferencingProperty, ISpecificationModel child)
            : base(model, externallyReferencingProperty)
        {
            this.relationshipType = RelationshipType.Marriage;

            this.child = child;
        }

        public SignificantOther(ISpecificationModel model, ISpecificationModel relatedModel, ISpecificationModel child)
            : base(model, relatedModel)
        {
            this.relationshipType = RelationshipType.Marriage;

            this.child = child;
        }
    }
}
