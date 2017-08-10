using System;

using Templates.Testing.Framework;

namespace Templates.Testing
{
    public class Recursive : Relationship, IRecursive
    {
        public override bool IsRecursive { get { return true; } }
        
        public Recursive(ISpecificationProperty referencingProperty)
            : base(referencingProperty, referencingProperty.Model)
        {
        }
    }
}
