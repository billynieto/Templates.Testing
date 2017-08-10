using System;

using Templates.Testing.Framework;

namespace Templates.Testing
{
    public class SingleParent : Parent, ISingleParent
    {
        public SingleParent(ISpecificationProperty referencingProperty, ISpecificationModel relatedModel)
            : base(referencingProperty, relatedModel)
        {
        }
    }
}
