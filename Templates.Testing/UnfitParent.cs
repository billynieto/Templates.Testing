using System;

using Templates.Testing.Framework;

namespace Templates.Testing
{
    public class UnfitParent : Parent, IUnfitParent
    {
        public UnfitParent(ISpecificationProperty referencingProperty, ISpecificationModel relatedModel)
            : base(referencingProperty, relatedModel)
        {
        }
    }
}
