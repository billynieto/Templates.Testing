using System;

namespace Templates.Testing.Framework
{
    public interface ISpecificationProperty
    {
        object Default { get; set; }
        string EnumerableOf { get; }
        string InstanceName { get; }
        bool IsCalculated { get; set; }
        bool IsDateOnly { get; set; }
        bool IsEnumeration { get; set; }
        bool IsList { get; set; }
        bool IsKey { get; set; }
        bool IsNullable { get; }
        string ListOf { get; }
        string ListInstanceName { get; }
        int? MantissaSize { get; set; }
        object Maximum { get; set; }
        object Minimum { get; set; }
        ISpecificationModel Model { get; set; }
        string Name { get; }
        string NewListOf { get; }
        string PropertyType { get; set; }
        bool ReadOnly { get; set; }
        IRelationship Relationship { get; set; }
        bool Required { get; }
    }
}
