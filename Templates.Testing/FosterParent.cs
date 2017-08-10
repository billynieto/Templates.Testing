using System;

using Templates.Testing.Framework;

namespace Templates.Testing
{
    public class FosterParent : Parent, IFosterParent
    {
        public FosterParent(ISpecificationProperty referencingProperty, ISpecificationModel relatedModel)
            : base(referencingProperty, relatedModel)
        {
        }
    }
}
