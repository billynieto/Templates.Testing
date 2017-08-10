using System;

using Templates.Testing.Framework;

namespace Templates.Testing
{
    public class Sibling : Relationship, ISibling
    {
        public Sibling(ISpecificationModel model, ISpecificationModel relatedModel)
            : base(model, relatedModel)
        {
        }
    }
}
