using System;

using Templates.Testing.Framework;

namespace Templates.Testing
{
    public class OnlyChild : Child, IOnlyChild
    {
        public OnlyChild(ISpecificationProperty referencingProperty, ISpecificationModel relatedModel)
            : base(referencingProperty, relatedModel)
        {
        }
    }
}
