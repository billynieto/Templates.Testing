using System;
using System.Collections.Generic;

using Templates.Framework;

namespace Templates.Testing.Framework
{
    public interface ISpecificationEnumeration
    {
        string EnumerableOf { get; }
        string InstanceName { get; set; }
        string InstanceReferenceName { get; set; }
        IList<ISpecificationEnumerationItem> Items { get; set; }
        string ListInstanceName { get; set; }
        string ListInstanceNameReference { get; set; }
        string ListOf { get; }
        string Name { get; }
    }

    public interface ISpecificationEnumerationItem
    {
        string Name { get;  }
        string Value { get;  }
    }
}
