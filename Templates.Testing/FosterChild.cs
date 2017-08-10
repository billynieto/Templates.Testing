using System;

using Templates.Testing.Framework;

namespace Templates.Testing
{
    public class FosterChild : Child, IFosterChild
    {
        public FosterChild(ISpecificationProperty referencingProperty, ISpecificationModel relatedModel)
            : base(referencingProperty, relatedModel)
        {
        }
    }
}
