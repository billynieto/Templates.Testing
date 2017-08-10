using System;

using Templates.Testing.Framework;

namespace Templates.Testing
{
    public class Grandparent : Parent, IGrandparent
    {
        public Grandparent(ISpecificationProperty specificationProperty, ISpecificationModel relatedModel)
            : base(specificationProperty, relatedModel)
        {
        }

        public Grandparent(ISpecificationModel model, ISpecificationProperty externallyReferencingProperty)
            : base(model, externallyReferencingProperty)
        {
        }
    }
}
