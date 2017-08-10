using System;

using Templates.Testing.Framework;

namespace Templates.Testing
{
    public class Marriage : SignificantOther, IMarriage
    {
        public Marriage(ISpecificationModel model, ISpecificationModel relatedModel, ISpecificationModel child)
            : base(model, relatedModel, child)
        {
        }
    }
}
