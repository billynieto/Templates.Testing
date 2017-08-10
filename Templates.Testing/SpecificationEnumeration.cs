using System;
using System.Collections.Generic;

using Templates.Testing.Framework;

namespace Templates.Testing
{
    public class SpecificationEnumeration : ISpecificationEnumeration
    {
        protected string instanceName;
        protected string instanceReferenceName;
        protected string listInstanceName;
        protected string listInstanceNameReference;
        protected ISpecificationModel model;
        protected string name;
        protected IList<ISpecificationEnumerationItem> items { get; set; }

        public string EnumerableOf { get { return "IEnumerable<" + this.name + ">"; } }
        public string InstanceName { get { return this.instanceName; } set { this.instanceName = value; } }
        public string InstanceReferenceName { get { if (this.instanceReferenceName == null) this.instanceReferenceName = this.instanceName.Substring(0, 1).ToUpper() + this.instanceName.Substring(1, this.instanceName.Length - 1); return this.instanceReferenceName; } set { this.instanceReferenceName = value; } }
        public IList<ISpecificationEnumerationItem> Items { get { return this.items; } set { this.items = value; } }
        public string ListInstanceName { get { return this.listInstanceName; } set { this.listInstanceName = value; } }
        public string ListInstanceNameReference { get { if (this.listInstanceNameReference == null) this.listInstanceNameReference = this.listInstanceName.Substring(0, 1).ToUpper() + this.listInstanceName.Substring(1, this.listInstanceName.Length - 1); return this.listInstanceNameReference; } set { this.listInstanceNameReference = value; } }
        public string ListOf { get { return "IList<" + this.name + ">"; } }
        public string Name { get { return this.name; } }

        public SpecificationEnumeration(string name)
        {
            this.name = name;

            this.items = new List<ISpecificationEnumerationItem>();
        }
    }

    public class SpecificationEnumerationItem : ISpecificationEnumerationItem
    {
        public string Name { get; }
        public string Value { get; }

        public SpecificationEnumerationItem(string name)
            : this(name, null)
        {
        }

        public SpecificationEnumerationItem(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}
