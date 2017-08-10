using System;

using Templates.Testing.Framework;

namespace Templates.Testing
{
    public class Seperated : SignificantOther, ISeperated
    {
        public Seperated(ISpecificationModel model, ISpecificationModel relatedModel, ISpecificationModel child)
            : base(model, relatedModel, child)
        {
        }
    }
}
