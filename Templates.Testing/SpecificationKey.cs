using System;
using System.Collections.Generic;

using Templates.Testing.Framework;

namespace Templates.Testing
{
    public class SpecificationKey : ISpecificationKey
    {
        protected string generateMock;
        protected string generateStub;
        protected string instanceName;
        protected string instanceReferenceName;
        protected string interfaceName;
        protected string listInstanceName;
        protected string listInstanceNameReference;
        protected string mock;
        protected ISpecificationModel model;
        protected string name;
        protected IList<ISpecificationProperty> specificationProperties { get; set; }

        public string EnumerableOf { get { return "IEnumerable<" + InterfaceName + ">"; } }
        public string GenerateMock { get { if (string.IsNullOrWhiteSpace(this.generateMock)) this.generateMock = "new " + Mock + "()"; return this.generateMock; } }
        public string GenerateStub { get { if (string.IsNullOrWhiteSpace(this.generateStub)) this.generateStub = "MockRepository.GenerateStub<" + InterfaceName + ">()"; return this.generateStub; } }
        public string InstanceName { get { if (this.instanceName == null) this.instanceName = Name.Substring(0, 1).ToLower() + Name.Substring(1, Name.Length - 1); return this.instanceName; } set { this.instanceName = value; } }
        public string InstanceReferenceName { get { if (this.instanceReferenceName == null) this.instanceReferenceName = InstanceName.Substring(0, 1).ToUpper() + InstanceName.Substring(1, InstanceName.Length - 1); return this.instanceReferenceName; } set { this.instanceReferenceName = value; } }
        public string InterfaceName { get { if (this.interfaceName == null) this.interfaceName = "I" + Name; return this.interfaceName; } set { this.interfaceName = value; } }
        public string ListInstanceName { get { if (this.listInstanceName == null) { this.listInstanceName = TestingHelper.Pluralize(InstanceName); } return this.listInstanceName; } set { this.listInstanceName = value; } }
        public string ListInstanceNameReference { get { if (this.listInstanceNameReference == null) this.listInstanceNameReference = ListInstanceName.Substring(0, 1).ToUpper() + ListInstanceName.Substring(1, ListInstanceName.Length - 1); return this.listInstanceNameReference; } set { this.listInstanceNameReference = value; } }
        public string ListOf { get { return "IList<" + InterfaceName + ">"; } }
        public string Mock { get { if (string.IsNullOrWhiteSpace(this.mock)) this.mock = "Mock<" + InterfaceName + ">"; return this.mock; } }
        public ISpecificationModel Model { get { return this.model; } }
        public string Name { get { return this.name; } set { this.name = value; } }
        public string NewListOf { get { return "new List<" + InterfaceName + ">()"; } }
        public IList<ISpecificationProperty> SpecificationProperties { get { return this.specificationProperties; } set { this.specificationProperties = value; } }

        public SpecificationKey(ISpecificationModel model)
            : this(model, model.KeyVariable.VariableType.Name)
        {
        }

        public SpecificationKey(ISpecificationModel model, string name)
        {
            this.model = model;
            this.name = name;

            this.specificationProperties = new List<ISpecificationProperty>();
        }
    }
}
