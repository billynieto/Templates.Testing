using System;

using Templates.Testing.Framework;

namespace Templates.Testing
{
    public class Admire : Associated, IAdmire
    {
        public Admire(ISpecificationProperty referencingProperty, ISpecificationModel relatedModel)
            : base(referencingProperty, relatedModel)
        {
        }
    }
}
