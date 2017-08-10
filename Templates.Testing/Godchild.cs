using System;

using Templates.Testing.Framework;

namespace Templates.Testing
{
    public class Godchild : Child, IGodchild
    {
        public Godchild(ISpecificationProperty referencingProperty, ISpecificationModel relatedModel)
            : base(referencingProperty, relatedModel)
        {
        }
    }
}
