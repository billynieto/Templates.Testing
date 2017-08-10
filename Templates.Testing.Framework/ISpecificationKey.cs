using System;
using System.Collections.Generic;

using Templates.Framework;

namespace Templates.Testing.Framework
{
    public interface ISpecificationKey
    {
        string EnumerableOf { get; }
        string GenerateMock { get; }
        string GenerateStub { get; }
        string InstanceName { get; set; }
        string InstanceReferenceName { get; set; }
        string InterfaceName { get; set; }
        string ListInstanceName { get; set; }
        string ListInstanceNameReference { get; set; }
        string ListOf { get; }
        string Mock { get; }
        ISpecificationModel Model { get; }
        string Name { get; set; }
        string NewListOf { get; }
        IList<ISpecificationProperty> SpecificationProperties { get; set; }
    }
}
