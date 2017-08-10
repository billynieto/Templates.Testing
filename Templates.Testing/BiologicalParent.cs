using System;

using Templates.Testing.Framework;

namespace Templates.Testing
{
    public class BiologicalParent : Parent, IBiologicalParent
    {
        public BiologicalParent(ISpecificationProperty referencingProperty, ISpecificationModel relatedModel)
            : base(referencingProperty, relatedModel)
        {
        }

        public BiologicalParent(ISpecificationModel model, ISpecificationModel relatedModel)
            : base(model, relatedModel)
        {
        }
    }
}
