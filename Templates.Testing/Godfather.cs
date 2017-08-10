using System;

using Templates.Testing.Framework;

namespace Templates.Testing
{
    public class Godfather : Parent, IGodfather
    {
        public Godfather(ISpecificationModel model, ISpecificationProperty externallyReferencingProperty)
            : base(model, externallyReferencingProperty)
        {
        }
    }
}
