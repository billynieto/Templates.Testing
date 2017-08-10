using System;

using Templates.Testing.Framework;

namespace Templates.Testing
{
    public class SpecificationProperty : ISpecificationProperty
    {
        protected string instanceName;
        protected bool isCalculated;
        protected bool isDateOnly;
        protected bool isList;
        protected bool isKey;
        protected string listInstanceName;
        protected int? mantissaSize;
        protected object maximum;
        protected object minimum;
        protected ISpecificationModel model;
        protected string name;
        protected string propertyType;
        protected bool readOnly;
        protected IRelationship relationship;
        protected bool required;

        public string EnumerableOf { get { return "IEnumerable<" + this.propertyType + ">"; } }
        public string InstanceName { get { return this.instanceName; } }
        public bool IsCalculated { get { return this.isCalculated; } set { this.isCalculated = value; } }
        public bool IsDateOnly { get { return this.isDateOnly; } set { this.isDateOnly = value; } }
        public bool IsList { get { return this.isList; } set { this.isList = value; Validate(); } }
        public virtual bool IsKey { get { return this.isKey; } set { this.isKey = value; } }
        public string ListOf { get { return "IList<" + this.propertyType + ">"; } }
        public string ListInstanceName { get { return this.listInstanceName; } }
        public int? MantissaSize { get { return this.mantissaSize; } set { this.mantissaSize = value; } }
        public object Maximum { get { return this.maximum; } set { this.maximum = value; } }
        public object Minimum { get { return this.minimum; } set { this.minimum = value; } }
        public ISpecificationModel Model { get { return this.model; } set { this.model = value; } }
        public string Name { get { return this.name; } }
        public string NewListOf { get { return "new List<" + this.propertyType + ">()"; } }
        public string PropertyType { get { return this.propertyType; } set { this.propertyType = value; } }
        public bool ReadOnly { get { return this.readOnly; } set { this.readOnly = value; } }
        public IRelationship Relationship { get { return this.relationship; } set { this.relationship = value; } }
        public bool Required { get { return this.required; } }

        public SpecificationProperty(ISpecificationModel model, string name, string propertyType, bool required)
        {
            this.model = model;
            this.name = name;
            this.propertyType = propertyType;
            this.required = required;

            string common = this.name.Substring(1, this.name.Length - 1);
            this.instanceName = this.name.Length <= 2 ? this.name.ToLower() : this.name.Substring(0, 1).ToLower() + common;
            this.name = this.name.Substring(0, 1).ToUpper() + common;

            if (this.instanceName.EndsWith("y"))
                this.listInstanceName = this.instanceName.Substring(0, this.instanceName.Length - 1) + "ies";
            else if (this.instanceName.EndsWith("ss"))
                this.listInstanceName = this.instanceName + "es";
            else if (this.instanceName.EndsWith("s"))
                this.listInstanceName = this.instanceName;
            else
                this.listInstanceName = this.instanceName + "s";

            this.relationship = null;
        }

        protected virtual void Validate()
        {
        }
    }
}
