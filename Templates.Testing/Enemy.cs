using System;

using Templates.Testing.Framework;

namespace Templates.Testing
{
    public class Enemy : Associated, IEnemy
    {
        public Enemy(ISpecificationModel model, ISpecificationProperty externallyReferencingProperty)
            : base(model, externallyReferencingProperty)
        {
        }

        public Enemy(ISpecificationProperty specificationProperty, ISpecificationModel relatedModel)
            : base(specificationProperty, relatedModel)
        {
        }
    }
}
