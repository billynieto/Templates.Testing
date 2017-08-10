using System;
using System.Collections.Generic;

using Templates.Testing.Framework;

namespace Templates.Testing
{
    public class BiologicalChild : Child, IBiologicalChild
    {
        protected ISpecificationModel father;
        protected ISpecificationModel mother;
        protected ISpecificationModel sibling;

        public BiologicalChild(ISpecificationProperty referencingProperty, ISpecificationModel relatedModel)
            : base(referencingProperty, relatedModel)
        {
            this.father = this.model;
            this.mother = this.relatedModel;
            this.sibling = null;
        }

        public ISpecificationModel Father { get { return this.father; } }

        public ISpecificationModel Mother { get { return this.mother; } }

        public ISpecificationModel Sibling { get { return this.sibling; } set { this.sibling = value; } }
    }
}
