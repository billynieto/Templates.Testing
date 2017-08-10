using System;

using Templates.Testing.Framework;

namespace Templates.Testing
{
    public class CustodiedChild : Child, ICustodiedChild
    {
        public CustodiedChild(ISpecificationModel model, ISpecificationProperty externallyReferencingProperty)
            : base(model, externallyReferencingProperty)
        {
        }
    }
}
