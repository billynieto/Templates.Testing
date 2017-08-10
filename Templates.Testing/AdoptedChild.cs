using System;
using System.Collections.Generic;

using Templates.Testing.Framework;

namespace Templates.Testing
{
    public class AdoptedChild : Child, IAdoptedChild
    {
        public AdoptedChild(ISpecificationProperty referencingProperty, ISpecificationModel relatedModel)
            : base(referencingProperty, relatedModel)
        {
        }
    }
}
