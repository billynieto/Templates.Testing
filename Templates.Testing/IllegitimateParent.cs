using System;

using Templates.Testing.Framework;

namespace Templates.Testing
{
    public class IllegitimateParent : Parent, IIllegitimateParent
    {
        public IllegitimateParent(ISpecificationProperty referencingProperty, ISpecificationModel relatedModel)
            : base(referencingProperty, relatedModel)
        {
        }
    }
}
