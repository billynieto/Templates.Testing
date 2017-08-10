using System;
using System.Collections.Generic;

namespace Templates.Testing.Framework
{
    /// <summary>
    /// I am Adopted by my parent Model.  I can only have 1 Adopting Parent, but they have multiple children (of me).
    /// </summary>
    public interface IAdoptedChild : IChild
    {
    }
}
