using System;

using Templates.Testing.Framework;

namespace Templates.Testing
{
    public class Grandchild : Child, IGrandchild
    {
        public Grandchild(ISpecificationProperty specificationProperty, ISpecificationModel relatedModel)
            : base(specificationProperty, relatedModel)
        {
        }
    }
}
