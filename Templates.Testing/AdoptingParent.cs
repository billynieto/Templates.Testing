using System;

using Templates.Testing.Framework;

namespace Templates.Testing
{
    public class AdoptingParent : Parent, IAdoptingParent
    {
        public AdoptingParent(ISpecificationProperty referencingProperty, ISpecificationModel relatedModel)
            : base(referencingProperty, relatedModel)
        {
        }
    }
}
