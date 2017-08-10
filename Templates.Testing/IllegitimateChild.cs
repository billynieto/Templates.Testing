using System;

using Templates.Testing.Framework;

namespace Templates.Testing
{
    public class IllegitimateChild : Child, IIllegitimateChild
    {
        public IllegitimateChild(ISpecificationProperty referencingProperty, ISpecificationModel relatedModel)
            : base(referencingProperty, relatedModel)
        {
        }
    }
}
