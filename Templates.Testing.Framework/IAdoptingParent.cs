using System;
using System.Collections.Generic;

namespace Templates.Testing.Framework
{
    /// <summary>
    /// I have Adopted this Model as my child.  I can have more than one of the Model, but they may only have 1 of me.
    /// </summary>
    public interface IAdoptingParent : IParent
    {
    }
}
