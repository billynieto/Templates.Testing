using System;

using Templates.Testing.Framework;

namespace Templates.Testing
{
    public class Friend : Associated, IFriend
    {
        public Friend(ISpecificationModel model, ISpecificationProperty externallyReferencingProperty)
            : base(model, externallyReferencingProperty)
        {
        }

        public Friend(ISpecificationProperty referencingProperty, ISpecificationModel relatedModel)
            : base(referencingProperty, relatedModel)
        {
        }
    }
}
