using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Xml;

using Templates.Framework;
using Templates.Testing.Framework;

namespace Templates.Testing
{
    public class Specification : ISpecification
    {
        protected IVariableType connectionStateType;
        protected IVariable connectionStateVariable;
        protected IVariable dataSetVariable;
        protected IInterface keyInterface;
        protected IInterface modelInterface;
        protected IClass modelClass;
        protected IClass modelFactoryClass;
        protected IInterface modelFactoryInterface;
        protected IList<IVariable> modelFactoryParameter;
        protected IVariableType modelFactoryType;
        protected IVariable modelFactoryVariable;
        protected IInterface multipleSearchInterface;
        protected IInterface repositoryInterface;
        protected IInterface serviceInterface;
        protected IInterface singleSearchInterface;
        protected IVariable testContextVariable;
        protected IVariable transactionVariable;

        protected IList<string> comments;
        protected Dictionary<string, ISpecificationEnumeration> enumerations;
        protected IList<string> errors;
        protected Dictionary<string, ISpecificationModel> models;
        protected IList<IList<ISpecificationModel>> rankedModels;
        protected IList<IRelationship> relationships;
        protected ISpecificationSettings settings;
        protected IList<string> warnings;
        
        public IVariableType ConnectionStateType { get { if (this.connectionStateType == null) this.connectionStateType = new TemplateVariableType("ConnectionState"); return this.connectionStateType; } }
        public IVariable ConnectionStateVariable { get { if (this.connectionStateVariable == null) this.connectionStateVariable = new TemplateVariable(ConnectionStateType, "State"); return this.connectionStateVariable; } }
        public IVariable DataSetVariable { get { if (this.dataSetVariable == null) this.dataSetVariable = new TemplateVariable(TemplateVariableType.DataSet, "dataSet"); return this.dataSetVariable; } }
        public IInterface KeyInterface { get { if (this.keyInterface == null) this.keyInterface = new TemplateInterface(TestingHelper.RepositoryFrameworkNamespace, "IKey"); return this.keyInterface; } }
        public IClass ModelClass { get { if (this.modelClass == null) this.modelClass = new TemplateClass(TestingHelper.RepositoryNamespace, "Model"); return this.modelClass; } }
        public IClass ModelFactoryClass { get { if (this.modelFactoryClass == null) this.modelFactoryClass = new TemplateClass(Settings.ModelsNamespace, "ModelFactory"); return this.modelFactoryClass; } }
        public IInterface ModelInterface { get { if (this.modelInterface == null) this.modelInterface = new TemplateInterface(TestingHelper.RepositoryFrameworkNamespace, "IModel"); return this.modelInterface; } }
        public IInterface ModelFactoryInterface { get { if (this.modelFactoryInterface == null) this.modelFactoryInterface = new TemplateInterface(Settings.FrameworkModelsNamespace, "IModelFactory"); return this.modelFactoryInterface; } }
        public IList<IVariable> ModelFactoryParameter { get { if (this.modelFactoryParameter == null) this.modelFactoryParameter = new List<IVariable>() { ModelFactoryVariable }; return this.modelFactoryParameter; } }
        public IVariable ModelFactoryVariable { get { if (this.modelFactoryVariable == null) this.modelFactoryVariable = new TemplateVariable(ModelFactoryInterface.Name, ModelFactoryClass.Name); return this.modelFactoryVariable; } }
        public IInterface MultipleSearchInterface { get { if (this.multipleSearchInterface == null) this.multipleSearchInterface = new TemplateInterface(TestingHelper.RepositoryFrameworkNamespace, "IMultipleSearch"); return this.multipleSearchInterface; } }
        public IInterface RepositoryInterface { get { if (this.repositoryInterface == null) this.repositoryInterface = new TemplateInterface(TestingHelper.RepositoryFrameworkNamespace, "IRepository"); return this.repositoryInterface; } }
        public IInterface ServiceInterface { get { if (this.serviceInterface == null) this.serviceInterface = new TemplateInterface(TestingHelper.RepositoryFrameworkNamespace, "IService"); return this.serviceInterface; } }
        public IInterface SingleSearchInterface { get { if (this.singleSearchInterface == null) this.singleSearchInterface = new TemplateInterface(TestingHelper.RepositoryFrameworkNamespace, "ISingleSearch"); return this.singleSearchInterface; } }
        public IVariable TestContextVariable { get { if (this.testContextVariable == null) this.testContextVariable = new TemplateVariable("TestContext", "testContext"); return this.testContextVariable; } }
        public IVariable TransactionVariable { get { if (this.transactionVariable == null) this.transactionVariable = new TemplateVariable("IDbTransaction", "transaction"); return this.transactionVariable; } }

        public IList<string> Comments { get { return this.comments; } set { this.comments = value; } }
        public Dictionary<string, ISpecificationEnumeration> Enumerations { get { return this.enumerations; } set { this.enumerations = value; } }
        public IList<string> Errors { get { return this.errors; } set { this.errors = value; } }
        public Dictionary<string, ISpecificationModel> Models { get { return this.models; } set { this.models = value; } }
        public IList<IRelationship> Relationships { get { return this.relationships; } set { this.relationships = value; } }
        public ISpecificationSettings Settings { get { return this.settings; } set { this.settings = value; } }
        public IList<string> Warnings { get { return this.warnings; } set { this.warnings = value; } }

        public Specification(string solutionName)
        {
            this.comments = new List<string>();
            this.enumerations = new Dictionary<string, ISpecificationEnumeration>();
            this.errors = new List<string>();
            this.models = new Dictionary<string, ISpecificationModel>();
            this.relationships = new List<IRelationship>();
            this.settings = new SpecificationSettings(solutionName);
            this.warnings = new List<string>();
        }
        
        public static string GeneralizeType(string modelType)
        {
            if (modelType.StartsWith("I"))
                return modelType.Substring(1, modelType.Length - 1);

            return modelType;
        }

        public static ISpecification Load(DirectoryInfo directory)
        {
            ISpecification specification = new Specification(directory.Name);
            ITestingFactory testingFactory = new TestingFactory();

            List<XmlDocument> xmlDocuments = new List<XmlDocument>();

            foreach (FileInfo specificationFile in directory.GetFiles("*.xml"))
            {
                string defaultName = specificationFile.Name.Substring(0, specificationFile.Name.LastIndexOf("."));

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(specificationFile.FullName);

                XmlElement modelElement = xmlDocument.DocumentElement;

                if (modelElement.Name == "enumeration")
                {
                    ISpecificationEnumeration enumeration = ConvertEnumeration(specification, testingFactory, defaultName, modelElement);

                    if (enumeration != null)
                        specification.Enumerations[enumeration.Name] = enumeration;
                }
                else if (modelElement.Name == "model")
                {
                    ISpecificationModel model = ConvertModel(specification, testingFactory, defaultName, modelElement);

                    if (model != null)
                        specification.Models[model.Interface.VariableType.Name] = model;
                }
                else if (modelElement.Name == "settings")
                {
                    ISpecificationSettings settings = ConvertSpecificationSettings(specification, testingFactory, modelElement);

                    if (settings != null)
                        specification.Settings = settings;
                }
                else
                {
                    specification.Warnings.Add(new StringBuilder("XML File ").Append(defaultName).Append(" did not start with a 'model' or 'enumeration' element therefore there were no Models established for this file.").ToString());
                }
            }

            List<ISpecificationModel> modelsThatWereSplit = new List<ISpecificationModel>();
            List<ISpecificationModel> tertiaryModels = new List<ISpecificationModel>();
            foreach (ISpecificationModel model in specification.Models.Values.Where(_specificationModel => _specificationModel.Key != null && _specificationModel.Key.SpecificationProperties.Count() == 2))
            {
                ISpecificationProperty fathersSpecificationProperty = model.Key.SpecificationProperties[0];
                ISpecificationProperty mothersSpecificationProperty = model.Key.SpecificationProperties[1];

                if (specification.Models.ContainsKey(fathersSpecificationProperty.PropertyType)
                    && specification.Models.ContainsKey(mothersSpecificationProperty.PropertyType))
                {
                    modelsThatWereSplit.Add(model);

                    ISpecificationModel grandfatherModel = specification.Models.Values.First(_model =>
                        _model.Variable.VariableType.Name == fathersSpecificationProperty.PropertyType ||
                        _model.Interface.VariableType.Name == fathersSpecificationProperty.PropertyType);
                    ISpecificationModel grandmotherModel = specification.Models.Values.First(_model =>
                        _model.Variable.VariableType.Name == mothersSpecificationProperty.PropertyType ||
                        _model.Interface.VariableType.Name == mothersSpecificationProperty.PropertyType);

                    ISpecificationModel granddaughterModel = null;
                    if (grandmotherModel.SpecificationProperties.Values.Any(_specificationProperty => _specificationProperty.PropertyType == model.Interface.VariableType.Name))
                    {
                        granddaughterModel = Specification.ConveiveSpecificationModel(specification, testingFactory, model, grandmotherModel, grandfatherModel);
                        
                        tertiaryModels.Add(granddaughterModel);
                    }

                    ISpecificationModel grandsonModel = null;
                    if (grandfatherModel.SpecificationProperties.Values.Any(_specificationProperty => _specificationProperty.PropertyType == model.Interface.VariableType.Name))
                    {
                        grandsonModel = Specification.ConveiveSpecificationModel(specification, testingFactory, model, grandfatherModel, grandmotherModel);
                        
                        tertiaryModels.Add(grandsonModel);
                    }

                    if (granddaughterModel != null && grandsonModel != null)
                    {
                        granddaughterModel.SetupSiblingRelationship(grandsonModel);
                        grandsonModel.SetupSiblingRelationship(granddaughterModel);
                    }
                    
                    if (granddaughterModel != null && model.Interface.VariableType.Name != granddaughterModel.Interface.VariableType.Name)
                    {
                        foreach (ISpecificationProperty specificationProperty in grandmotherModel.SpecificationProperties.Values.Where(_specificationProperty => _specificationProperty.PropertyType == model.Interface.VariableType.Name))
                            specificationProperty.PropertyType = granddaughterModel.Interface.VariableType.Name;

                        foreach (ISpecificationProperty specificationProperty in grandsonModel.SpecificationProperties.Values.Where(_specificationProperty => _specificationProperty.PropertyType == model.Interface.VariableType.Name))
                            specificationProperty.PropertyType = granddaughterModel.Interface.VariableType.Name;
                    }

                    if (grandsonModel != null && model.Interface.VariableType.Name != grandsonModel.Interface.VariableType.Name)
                    {
                        foreach (ISpecificationProperty specificationProperty in grandfatherModel.SpecificationProperties.Values.Where(_specificationProperty => _specificationProperty.PropertyType == model.Interface.VariableType.Name))
                            specificationProperty.PropertyType = grandsonModel.Interface.VariableType.Name;

                        foreach (ISpecificationProperty specificationProperty in granddaughterModel.SpecificationProperties.Values.Where(_specificationProperty => _specificationProperty.PropertyType == model.Interface.VariableType.Name))
                            specificationProperty.PropertyType = grandsonModel.Interface.VariableType.Name;
                    }
                }
            }

            foreach (ISpecificationModel model in tertiaryModels)
                specification.Models[model.Interface.VariableType.Name] = model;
            foreach (ISpecificationModel model in modelsThatWereSplit)
                if (!tertiaryModels.Any(_tertiary => _tertiary.Interface.VariableType.Name == model.Interface.VariableType.Name))
                    specification.Models.Remove(model.Interface.VariableType.Name);

            foreach (ISpecificationModel model in specification.Models.Values)
            {
                IEnumerable<ISpecificationProperty> specificationProperties = model.SpecificationProperties.Values;

                if (model.Key != null)
                    specificationProperties = specificationProperties.Concat(model.Key.SpecificationProperties);

                foreach (ISpecificationProperty specificationProperty in specificationProperties)
                    if (specification.Models.ContainsKey(specificationProperty.PropertyType))
                        model.SetupRelationship(specification.Models[specificationProperty.PropertyType]);
            }

            foreach (ISpecificationModel model in specification.Models.Values)
            {
                IEnumerable<ISpecificationModel> allTheOtherModels = specification.Models.Values.Where(_model => _model.Variable.VariableType.Name != model.Variable.VariableType.Name).ToList();

                foreach (ISpecificationModel otherModel in allTheOtherModels)
                {
                    IRelationship existingRelationship = model.Relationships.Where(_relationship => _relationship.RelatedModel != null && _relationship.RelatedModel.Variable.VariableType.Name == otherModel.Variable.VariableType.Name).FirstOrDefault();
                    IRelationship reciprocatedRelationship = otherModel.Relationships.Where(_relationship => _relationship.RelatedModel != null && _relationship.RelatedModel.Variable.VariableType.Name == model.Variable.VariableType.Name).FirstOrDefault();

                    if (existingRelationship == null && reciprocatedRelationship != null)
                        model.SetupReciprocatedRelationship(otherModel, reciprocatedRelationship);
                }
            }
            
            return specification;
        }

        private static ISpecificationEnumeration ConvertEnumeration(ISpecification specification, ITestingFactory testingFactory, string defaultName, XmlElement modelElement)
        {
            ISpecificationEnumeration enumeration = null;

            XmlAttribute nameAttribute = modelElement.Attributes["name"];

            if (nameAttribute != null)
            {
                if (string.IsNullOrWhiteSpace(nameAttribute.Value))
                    specification.Errors.Add(new StringBuilder().Append(defaultName).Append(" identified a Name Attribute, but no name was actually specified.  This Enumeration was not established.").ToString());
                else
                    enumeration = testingFactory.GenerateEnumeration(nameAttribute.Value);
            }
            else
            {
                enumeration = testingFactory.GenerateEnumeration(defaultName);
            }

            if (enumeration != null)
            {
                foreach (XmlNode xmlNode in modelElement.ChildNodes)
                {
                    if (xmlNode is XmlElement)
                    {
                        XmlElement xmlElement = (XmlElement)xmlNode;
                        switch (xmlElement.Name)
                        {
                            case "items":
                                if (enumeration.Items == null || enumeration.Items.Count() == 0)
                                    enumeration.Items = new List<ISpecificationEnumerationItem>(ConvertSpecificationEnumerationItems(specification, enumeration, xmlElement).Values.OrderBy(_item => _item.Name));
                                else
                                    specification.Warnings.Add(new StringBuilder().Append(enumeration.Name).Append(" identified more than one set of Specification Enumeration Items.  Only the first set will be setup.").ToString());

                                break;
                        }
                    }
                }
            }

            return enumeration;
        }

        private static ISpecificationModel ConvertModel(ISpecification specification, ITestingFactory testingFactory, string defaultName, XmlElement modelElement)
        {
            ISpecificationModel model = null;

            if (modelElement.Name == "model")
            {
                XmlAttribute canDeleteAttribute = modelElement.Attributes["canDelete"];
                XmlAttribute canInsertAttribute = modelElement.Attributes["canInsert"];
                XmlAttribute canUpdateAttribute = modelElement.Attributes["canUpdate"];
                XmlAttribute nameAttribute = modelElement.Attributes["name"];
                XmlAttribute hasRepositoryAndServiceAttribute = modelElement.Attributes["hasRepositoryAndService"];
                XmlAttribute interfaceNameAttribute = modelElement.Attributes["interfaceName"];
                XmlAttribute isPrimaryModelAttribute = modelElement.Attributes["isPrimaryModel"];
                XmlAttribute readOnlyAttribute = modelElement.Attributes["readOnly"];
                
                if (nameAttribute != null)
                {
                    if (string.IsNullOrWhiteSpace(nameAttribute.Value))
                        specification.Errors.Add(new StringBuilder().Append(defaultName).Append(" identified a Name Attribute, but no name was actually specified.  This Model was not established.").ToString());
                    else
                        model = testingFactory.GenerateModel(specification, testingFactory, nameAttribute.Value);
                }
                else
                {
                    model = testingFactory.GenerateModel(specification, testingFactory, defaultName);
                }

                if (model != null)
                {
                    model.HasRepositoryAndService = hasRepositoryAndServiceAttribute == null || hasRepositoryAndServiceAttribute.Value.Trim().ToLower() != "false" ? true : false;
                    model.ReadOnly = readOnlyAttribute == null || readOnlyAttribute.Value.Trim().ToLower() == "false" ? false : true;

                    if (model.ReadOnly)
                    {
                        model.CanDelete = false;
                        model.CanInsert = false;
                        model.CanUpdate = false;

                        if (canDeleteAttribute != null)
                            specification.Warnings.Add(new StringBuilder().Append(model.Variable.VariableType.Name).Append(" is Read Only, but the Can Delete attribute is specified.  This attribute will be ignored.").ToString());
                        if (canDeleteAttribute != null)
                            specification.Warnings.Add(new StringBuilder().Append(model.Variable.VariableType.Name).Append(" is Read Only, but the Can Delete attribute is specified.  This attribute will be ignored.").ToString());
                        if (canDeleteAttribute != null)
                            specification.Warnings.Add(new StringBuilder().Append(model.Variable.VariableType.Name).Append(" is Read Only, but the Can Delete attribute is specified.  This attribute will be ignored.").ToString());
                    }
                    else
                    {
                        model.CanDelete = canDeleteAttribute == null || canDeleteAttribute.Value.Trim().ToLower() != "false" ? true : false;
                        model.CanInsert = canInsertAttribute == null || canInsertAttribute.Value.Trim().ToLower() != "false" ? true : false;
                        model.CanUpdate = canUpdateAttribute == null || canUpdateAttribute.Value.Trim().ToLower() != "false" ? true : false;
                    }

                    if (isPrimaryModelAttribute != null && isPrimaryModelAttribute.Value.Trim().ToLower() == "false")
                        model.Tier = Tier.Secondary;

                    foreach (XmlNode xmlNode in modelElement.ChildNodes)
                    {
                        if (xmlNode is XmlElement)
                        {
                            XmlElement xmlElement = (XmlElement)xmlNode;
                            switch (xmlElement.Name)
                            {
                                case "key":
                                    if (model.Key == null)
                                        model.Key = ConvertKey(specification, testingFactory, model, xmlElement);
                                    else
                                        specification.Warnings.Add(new StringBuilder().Append(model.Variable.VariableType.Name).Append(" identified more than one Key.  This is currently not supported, and only the first Key will be setup.").ToString());

                                    break;

                                case "specificationProperties":
                                    if (model.SpecificationProperties == null || model.SpecificationProperties.Count() == 0)
                                        model.SpecificationProperties = ConvertSpecificationProperties(specification, testingFactory, model, xmlElement, false);
                                    else
                                        specification.Warnings.Add(new StringBuilder().Append(model.Variable.VariableType.Name).Append(" identified more than one set of Specification Properties.  Only the first Key will be setup.").ToString());

                                    break;
                            }
                        }
                    }
                }
            }
            else
            {
                specification.Warnings.Add(new StringBuilder("XML File ").Append(defaultName).Append(" did not start with a 'model' element therefore there were no Models established for this file.").ToString());
            }

            return model;
        }

        private static ISpecificationKey ConvertKey(ISpecification specification, ITestingFactory testingFactory, ISpecificationModel model, XmlElement keyElement)
        {
            ISpecificationKey specificationKey = testingFactory.GenerateKey(model);

            XmlAttribute nameAttribute = keyElement.Attributes["name"];
            if (nameAttribute != null)
            {
                if (string.IsNullOrWhiteSpace(nameAttribute.Value))
                    specification.Warnings.Add(new StringBuilder().Append(model.Variable.VariableType.Name).Append(" Key identified a Name Attribute, but no name was actually specified.  This default Key Name will be used.").ToString());
                else
                    specificationKey.Name = nameAttribute.Value;
            }

            foreach (XmlNode xmlNode in keyElement.ChildNodes)
            {
                if (xmlNode is XmlElement)
                {
                    XmlElement xmlElement = (XmlElement)xmlNode;
                    switch (xmlElement.Name)
                    {
                        case "specificationProperties":
                            if (specificationKey.SpecificationProperties == null || specificationKey.SpecificationProperties.Count() == 0)
                                specificationKey.SpecificationProperties = new List<ISpecificationProperty>(ConvertSpecificationProperties(specification, testingFactory, model, xmlElement, true).Values);
                            else
                                specification.Warnings.Add(new StringBuilder().Append(model.Variable.VariableType.Name).Append(" Key identified more than one set of Specification Properties.  Only the first Key will be setup.").ToString());

                            break;
                    }
                }
            }

            return specificationKey;
        }

        private static ISpecificationEnumerationItem ConvertSpecificationEnumerationItem(ISpecification specification, ISpecificationEnumeration enumeration, XmlElement specificationEnumerationItemElement)
        {
            ISpecificationEnumerationItem specificationEnumerationItem = null;

            XmlAttribute nameAttribute = specificationEnumerationItemElement.Attributes["name"];
            XmlAttribute valueAttribute = specificationEnumerationItemElement.Attributes["value"];

            if (nameAttribute == null)
                specification.Errors.Add(new StringBuilder().Append(enumeration.Name).Append(" identified a Specifcation Enumeration Item without a 'name' attribute, therefore it is being skipped.").ToString());
            else if (string.IsNullOrWhiteSpace(nameAttribute.Value))
                specification.Errors.Add(new StringBuilder().Append(enumeration.Name).Append(" identified a Specifcation Enumeration Item with a 'name' attribute but it was not set, therefore it is being skipped.").ToString());

            if (valueAttribute != null && string.IsNullOrWhiteSpace(valueAttribute.Value))
                specification.Errors.Add(new StringBuilder().Append(enumeration.Name).Append(" identified a Specifcation Enumeration Item with a 'value' attribute but it was not set, therefore it is being skipped.").ToString());

            if (nameAttribute != null && !string.IsNullOrWhiteSpace(nameAttribute.Value))
            {
                string name = nameAttribute.Value.Trim();
                string value = valueAttribute == null ? null : valueAttribute.Value.Trim();

                specificationEnumerationItem = new SpecificationEnumerationItem(name, value);
            }

            return specificationEnumerationItem;
        }

        private static Dictionary<string, ISpecificationEnumerationItem> ConvertSpecificationEnumerationItems(ISpecification specification, ISpecificationEnumeration enumeration, XmlElement specificationEnumerationItemsElement)
        {
            Dictionary<string, ISpecificationEnumerationItem> specificationEnumerationItems = new Dictionary<string, ISpecificationEnumerationItem>();

            foreach (XmlNode xmlNode in specificationEnumerationItemsElement.ChildNodes)
            {
                if (xmlNode is XmlElement)
                {
                    XmlElement xmlElement = (XmlElement)xmlNode;
                    switch (xmlElement.Name)
                    {
                        case "item":
                            ISpecificationEnumerationItem specificationEnumerationItem = ConvertSpecificationEnumerationItem(specification, enumeration, xmlElement);

                            if (specificationEnumerationItem != null)
                                specificationEnumerationItems[specificationEnumerationItem.Name] = specificationEnumerationItem;

                            break;
                    }
                }
            }

            return specificationEnumerationItems;
        }

        private static Dictionary<string, ISpecificationProperty> ConvertSpecificationProperties(ISpecification specification, ITestingFactory testingFactory, ISpecificationModel model, XmlElement specificationPropertiesElement, bool isKey)
        {
            Dictionary<string, ISpecificationProperty> specificationProperties = new Dictionary<string, ISpecificationProperty>();

            foreach (XmlNode xmlNode in specificationPropertiesElement.ChildNodes)
            {
                if (xmlNode is XmlElement)
                {
                    XmlElement xmlElement = (XmlElement)xmlNode;
                    switch (xmlElement.Name)
                    {
                        case "specificationProperty":
                            ISpecificationProperty specificationProperty = ConvertSpecificationProperty(specification, testingFactory, model, xmlElement, isKey);

                            if (specificationProperty != null)
                                specificationProperties[specificationProperty.Name] = specificationProperty;

                            break;
                    }
                }
            }

            return specificationProperties;
        }

        private static ISpecificationProject ConvertSpecificationProject(ISpecification specification, ITestingFactory testingFactory, XmlElement specificationProjectElement, string projectType, string defaultName)
        {
            ISpecificationProject project = null;

            XmlAttribute nameAttribute = specificationProjectElement.Attributes["name"];

            if (nameAttribute == null)
                specification.Errors.Add(new StringBuilder().Append("The ").Append(projectType).Append(" Project didn't have a 'name' attribute, therefore the default name will be used.").ToString());
            else if (string.IsNullOrWhiteSpace(nameAttribute.Value))
                specification.Errors.Add(new StringBuilder().Append("The ").Append(projectType).Append(" Project identified a 'name' attribute but it was not set, therefore the default name will be used.").ToString());

            string name = nameAttribute != null && !string.IsNullOrWhiteSpace(nameAttribute.Value) ? nameAttribute.Value.Trim() : defaultName;

            project = testingFactory.GenerateProject();
            project.Name = name;

            return project;
        }

        private static ISpecificationProperty ConvertSpecificationProperty(ISpecification specification, ITestingFactory testingFactory, ISpecificationModel model, XmlElement specificationPropertyElement, bool isKey)
        {
            ISpecificationProperty specificationProperty = null;

            XmlAttribute isCalculatedAttribute = specificationPropertyElement.Attributes["isCalculated"];
            XmlAttribute isDateOnlyAttribute = specificationPropertyElement.Attributes["isDateOnly"];
            XmlAttribute nameAttribute = specificationPropertyElement.Attributes["name"];
            XmlAttribute mantissaSizeAttribute = specificationPropertyElement.Attributes["mantissaSize"];
            XmlAttribute propertyTypeAttribute = specificationPropertyElement.Attributes["propertyType"];
            XmlAttribute readOnlyAttribute = specificationPropertyElement.Attributes["readOnly"];
            XmlAttribute requiredAttribute = specificationPropertyElement.Attributes["required"];

            if (nameAttribute == null)
                specification.Errors.Add(new StringBuilder().Append(model.Variable.VariableType.Name).Append(" identified a Specifcation Property without a 'name' attribute, therefore it is being skipped.").ToString());
            else if (string.IsNullOrWhiteSpace(nameAttribute.Value))
                specification.Errors.Add(new StringBuilder().Append(model.Variable.VariableType.Name).Append(" identified a Specifcation Property with a 'name' attribute but it was not set, therefore it is being skipped.").ToString());

            if (propertyTypeAttribute == null)
                specification.Errors.Add(new StringBuilder().Append(model.Variable.VariableType.Name).Append(" identified a Specifcation Property without a 'propertyType' attribute, therefore it is being skipped.").ToString());
            else if (string.IsNullOrWhiteSpace(propertyTypeAttribute.Value))
                specification.Errors.Add(new StringBuilder().Append(model.Variable.VariableType.Name).Append(" identified a Specifcation Property with a 'propertyType' attribute but it was not set, therefore it is being skipped.").ToString());

            if (nameAttribute != null && !string.IsNullOrWhiteSpace(nameAttribute.Value) &&
                propertyTypeAttribute != null && !string.IsNullOrWhiteSpace(propertyTypeAttribute.Value))
            {
                bool isCalculated = isCalculatedAttribute == null || isCalculatedAttribute.Value.Trim().ToLower() == "false" ? false : true;
                bool isDateOnly = isDateOnlyAttribute == null || isDateOnlyAttribute.Value.Trim().ToLower() == "false" ? false : true;
                string name = nameAttribute.Value.Trim();
                int? mantissaSize = null;
                string propertyType = propertyTypeAttribute.Value.Trim();
                bool readOnly = readOnlyAttribute == null || readOnlyAttribute.Value.Trim().ToLower() == "false" ? false : true;
                bool required = requiredAttribute != null && requiredAttribute.Value.Trim().ToLower() != "false" ? true : false;

                if (mantissaSizeAttribute != null && mantissaSizeAttribute.Value.Trim().Length > 0)
                {
                    int temp = 0;
                    if (!Int32.TryParse(mantissaSizeAttribute.Value, out temp))
                        specification.Errors.Add(new StringBuilder().Append(model.Variable.VariableType.Name).Append(" identified a Specifcation Property with a 'mantissaSize' that was not a number, and therefore is being ignored.").ToString());
                    else
                        mantissaSize = temp;
                }

                specificationProperty = testingFactory.GenerateProperty(model, name, propertyType, required);

                specificationProperty.IsCalculated = isCalculated;
                specificationProperty.IsDateOnly = isDateOnly;
                specificationProperty.IsKey = isKey;
                specificationProperty.MantissaSize = mantissaSize;
                specificationProperty.ReadOnly = readOnly;

                XmlAttribute isListAttribute = specificationPropertyElement.Attributes["isList"];
                if (isListAttribute != null && isListAttribute.Value.Trim().ToLower() != "false")
                    specificationProperty.IsList = true;

                XmlAttribute maximumAttribute = specificationPropertyElement.Attributes["maximum"];
                if (maximumAttribute != null)
                {
                    if (string.IsNullOrWhiteSpace(maximumAttribute.Value))
                        specification.Errors.Add(new StringBuilder().Append(model.Variable.VariableType.Name).Append(".").Append(specificationProperty.Name).Append(" identified a 'maximum' attribute but it was not set, therefore it is being skipped.").ToString());
                    else if (specificationProperty.PropertyType.StartsWith("DateTime"))
                        specificationProperty.Maximum = Convert.ToDateTime(maximumAttribute.Value);
                    else
                        specificationProperty.Maximum = Convert.ToInt32(maximumAttribute.Value);
                }
                else
                {
                    if (propertyType.ToLower() == "string")
                    {
                        specification.Errors.Add(new StringBuilder().Append(model.Variable.VariableType.Name).Append(" ").Append(name).Append(" is a string and MUST have a Maximum value set.").ToString());

                        specificationProperty.Maximum = 1;
                    }
                }

                XmlAttribute minimumAttribute = specificationPropertyElement.Attributes["minimum"];
                if (minimumAttribute != null)
                {
                    if (string.IsNullOrWhiteSpace(minimumAttribute.Value))
                        specification.Errors.Add(new StringBuilder().Append(model.Variable.VariableType.Name).Append(".").Append(specificationProperty.Name).Append(" identified a 'minimum' attribute but it was not set, therefore it is being skipped.").ToString());
                    else if (specificationProperty.PropertyType.StartsWith("DateTime"))
                        specificationProperty.Minimum = Convert.ToDateTime(minimumAttribute.Value);
                    else
                        specificationProperty.Minimum = Convert.ToInt32(minimumAttribute.Value);
                }
                else
                {
                    if (propertyType.ToLower() == "string" && (specificationProperty.IsKey || specificationProperty.Required))
                    {
                        specification.Errors.Add(new StringBuilder().Append(model.Variable.VariableType.Name).Append(" ").Append(name).Append(" is a ").Append(specificationProperty.IsKey ? "Key" : "Required").Append(" string and MUST have a Minimum value set.").ToString());

                        specificationProperty.Minimum = 1;
                    }
                }
            }

            return specificationProperty;
        }

        private static ISpecificationSolution ConvertSpecificationSolution(ISpecification specification, ITestingFactory testingFactory, XmlElement specificationSolutionElement)
        {
            ISpecificationProject project = null;
            ISpecificationSolution solution = specification.Settings.Solution;

            foreach (XmlNode xmlNode in specificationSolutionElement.ChildNodes)
            {
                if (xmlNode is XmlElement)
                {
                    XmlElement xmlElement = (XmlElement)xmlNode;
                    switch (xmlElement.Name)
                    {
                        case "frameworkProject":
                            project = ConvertSpecificationProject(specification, testingFactory, xmlElement, "Framework", solution.FrameworkProject.Name);

                            if (project != null)
                                solution.FrameworkProject = project;

                            break;

                        case "integrationTestProject":
                            project = ConvertSpecificationProject(specification, testingFactory, xmlElement, "Integration Test", solution.IntegrationTestProject.Name);

                            if (project != null)
                                solution.IntegrationTestProject = project;

                            break;

                        case "modelProject":
                            project = ConvertSpecificationProject(specification, testingFactory, xmlElement, "Model", solution.ModelProject.Name);

                            if (project != null)
                                solution.ModelProject = project;

                            break;

                        case "repositoryProject":
                            project = ConvertSpecificationProject(specification, testingFactory, xmlElement, "Repository", solution.RepositoryProject.Name);

                            if (project != null)
                                solution.RepositoryProject = project;

                            break;

                        case "serviceProject":
                            project = ConvertSpecificationProject(specification, testingFactory, xmlElement, "Service", solution.ServiceProject.Name);

                            if (project != null)
                                solution.ServiceProject = project;

                            break;

                        case "unitTestProject":
                            project = ConvertSpecificationProject(specification, testingFactory, xmlElement, "Unit Test", solution.UnitTestProject.Name);

                            if (project != null)
                                solution.UnitTestProject = project;

                            break;
                    }
                }
            }

            return solution;
        }

        private static ISpecificationSettings ConvertSpecificationSettings(ISpecification specification, ITestingFactory testingFactory, XmlElement specificationSettingsElement)
        {
            ISpecificationSettings settings = specification.Settings;

            foreach (XmlNode xmlNode in specificationSettingsElement.ChildNodes)
            {
                if (xmlNode is XmlElement)
                {
                    XmlElement xmlElement = (XmlElement)xmlNode;
                    switch (xmlElement.Name)
                    {
                        case "solution":
                            ISpecificationSolution solution = ConvertSpecificationSolution(specification, testingFactory, xmlElement);

                            if (solution != null)
                                settings.Solution = solution;

                            break;
                    }
                }
            }

            return settings;
        }

        private static ISpecificationModel ConveiveSpecificationModel(ISpecification specification, ITestingFactory testingFactory, ISpecificationModel model, ISpecificationModel relatedModel, ISpecificationModel spouse)
        {
            ISpecificationModel morphedModel = testingFactory.GenerateModel(specification, testingFactory, relatedModel.Variable.VariableType.Name + spouse.Variable.VariableType.Name);
            morphedModel.HasRepositoryAndService = model.HasRepositoryAndService;

            morphedModel.Key = testingFactory.GenerateKey(morphedModel);
            foreach (ISpecificationProperty keySpecificationProperty in relatedModel.Key.SpecificationProperties)
            {
                ISpecificationProperty newSpecificationProperty = testingFactory.GenerateProperty(morphedModel, relatedModel.Variable.VariableType.Name + keySpecificationProperty.Name, keySpecificationProperty.PropertyType, keySpecificationProperty.Required);
                newSpecificationProperty.Maximum = keySpecificationProperty.Maximum;
                newSpecificationProperty.Minimum = keySpecificationProperty.Minimum;

                morphedModel.Key.SpecificationProperties.Add(newSpecificationProperty);
            }
            foreach (ISpecificationProperty keySpecificationProperty in spouse.Key.SpecificationProperties)
            {
                ISpecificationProperty newSpecificationProperty = testingFactory.GenerateProperty(morphedModel, spouse.Variable.VariableType.Name + keySpecificationProperty.Name, keySpecificationProperty.PropertyType, keySpecificationProperty.Required);
                newSpecificationProperty.Maximum = keySpecificationProperty.Maximum;
                newSpecificationProperty.Minimum = keySpecificationProperty.Minimum;

                morphedModel.Key.SpecificationProperties.Add(newSpecificationProperty);
            }
            
            foreach (ISpecificationProperty specificationProperty in model.SpecificationProperties.Values.Concat(spouse.SpecificationProperties.Values))
            {
                ISpecificationProperty newSpecificationProperty = testingFactory.GenerateProperty(morphedModel, specificationProperty.Name, specificationProperty.PropertyType, specificationProperty.Required);
                newSpecificationProperty.IsList = specificationProperty.IsList;
                newSpecificationProperty.Maximum = specificationProperty.Maximum;
                newSpecificationProperty.Minimum = specificationProperty.Minimum;

                morphedModel.SpecificationProperties.Add(newSpecificationProperty.Name, newSpecificationProperty);
            }

            morphedModel.ReadOnly = model.ReadOnly;

            if (!morphedModel.ReadOnly)
            {
                morphedModel.CanDelete = model.CanDelete;
                morphedModel.CanInsert = model.CanInsert;
                morphedModel.CanUpdate = model.CanUpdate;
            }

            morphedModel.Tier = Tier.Tertiary;

            return morphedModel;
        }
    }
}