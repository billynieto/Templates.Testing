using System;

namespace Templates.Testing.Framework
{
    /// <summary>
    /// I depend solely on my Biological Parent who I see as my Father.  My Mother is another Model, and I am here to represent a many-to-many relationship between my Mother and Father with additional data that each one can't live with alone.  My Mother and Father are married.  I can not exist if neither my Mother or Father don't exist.  They are listed as one of my keys.  I have a sibling Model that is very similar to me, where I look like our Father and my sibling looks like our Mother.
    /// </summary>
    public interface IBiologicalChild : IChild
    {
        ISpecificationModel Father { get; }
        ISpecificationModel Mother { get; }
        ISpecificationModel Sibling { get; }
    }
}
 