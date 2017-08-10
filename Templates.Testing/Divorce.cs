using System;

using Templates.Testing.Framework;

namespace Templates.Testing
{
    public class Divorce : SignificantOther, IDivorce
    {
        public Divorce(ISpecificationModel model, ISpecificationModel relatedModel, ISpecificationModel child)
            : base(model, relatedModel, child)
        {
        }
    }
}
