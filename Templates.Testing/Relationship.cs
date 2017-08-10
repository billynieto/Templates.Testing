using System;

using Templates.Framework;
using Templates.Testing.Framework;

namespace Templates.Testing
{
    public abstract class Relationship : IRelationship
    {
        protected ISpecificationProperty externallyReferencingProperty;
        protected ISpecificationModel model;
        protected ISpecificationModel relatedModel;
        protected ISpecificationProperty referencingProperty;
        protected RelationshipType relationshipType;

        public ISpecificationProperty ExternallyReferencingProperty { get { return this.externallyReferencingProperty; } }
        public virtual bool IsRecursive { get { return false; } }
        public ISpecificationModel Model { get { return this.model; } }
        public ISpecificationProperty ReferencingProperty { get { return this.referencingProperty; } }
        public ISpecificationModel RelatedModel { get { return this.relatedModel; } }
        public RelationshipType Type { get { return this.relationshipType; } }

        public Relationship(ISpecificationProperty referencingProperty, ISpecificationProperty externallyReferencingProperty)
        {
            this.externallyReferencingProperty = externallyReferencingProperty;
            this.referencingProperty = referencingProperty;

            this.model = this.referencingProperty.Model;
            this.referencingProperty.Relationship = this;
            if (this.externallyReferencingProperty != null)
                this.relatedModel = this.externallyReferencingProperty.Model;
        }

        public Relationship(ISpecificationProperty referencingProperty, ISpecificationModel relatedModel)
        {
            this.relatedModel = relatedModel;
            this.referencingProperty = referencingProperty;

            this.externallyReferencingProperty = null;

            this.model = this.referencingProperty.Model;
            this.referencingProperty.Relationship = this;
        }

        public Relationship(ISpecificationModel model, ISpecificationProperty externallyReferencingProperty)
        {
            this.externallyReferencingProperty = externallyReferencingProperty;
            this.model = model;

            this.referencingProperty = null;

            if (this.externallyReferencingProperty != null)
                this.relatedModel = this.externallyReferencingProperty.Model;
        }

        public Relationship(ISpecificationModel model, ISpecificationModel relatedModel)
        {
            this.model = model;
            this.relatedModel = relatedModel;

            this.externallyReferencingProperty = null;
            this.referencingProperty = null;
        }
    }
}
