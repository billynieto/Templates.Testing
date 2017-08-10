using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Repository.Framework;
using Templates.Framework;

using Templates.Testing.Framework;

namespace Templates.Testing
{
    public static class TestingHelper
    {
        private static INamespace microsoftVisualStudioTestToolsUnitTestingNamespace;
        private static INamespace moqNamespace;
        private static INamespace repositoryNamespace;
        private static INamespace repositoryFrameworkNamespace;
        private static INamespace templatesNamespace;
        private static INamespace templatesFrameworkNamespace;
        private static INamespace templatesTestingNamespace;
        private static INamespace templatesTestingFrameworkNamespace;

        public static INamespace MicrosoftVisualStudioTestToolsUnitTestingNamespace {get { if (TestingHelper.microsoftVisualStudioTestToolsUnitTestingNamespace == null) TestingHelper.microsoftVisualStudioTestToolsUnitTestingNamespace = new TemplateNamespace("Microsoft.VisualStudio.TestTools.UnitTesting"); return TestingHelper.microsoftVisualStudioTestToolsUnitTestingNamespace; } }
        public static INamespace MoqNamespace {get { if (TestingHelper.moqNamespace == null) TestingHelper.moqNamespace = new TemplateNamespace("Moq"); return TestingHelper.moqNamespace; } }
        public static INamespace RepositoryNamespace { get { if (TestingHelper.repositoryNamespace == null) TestingHelper.repositoryNamespace = new TemplateNamespace("Repository"); return TestingHelper.repositoryNamespace; } }
        public static INamespace RepositoryFrameworkNamespace { get { if (TestingHelper.repositoryFrameworkNamespace == null) TestingHelper.repositoryFrameworkNamespace = new TemplateNamespace(RepositoryNamespace, "Framework"); return TestingHelper.repositoryFrameworkNamespace; } }
        public static INamespace TemplatesNamespace {get { if (TestingHelper.templatesNamespace == null) TestingHelper.templatesNamespace = new TemplateNamespace("Templates"); return TestingHelper.templatesNamespace; } }
        public static INamespace TemplatesFrameworkNamespace {get { if (TestingHelper.templatesFrameworkNamespace == null) TestingHelper.templatesFrameworkNamespace = new TemplateNamespace("Templates.Framework"); return TestingHelper.templatesFrameworkNamespace; } }
        public static INamespace TemplatesTestingNamespace {get { if (TestingHelper.templatesTestingNamespace == null) TestingHelper.templatesTestingNamespace = new TemplateNamespace("Templates.Testing"); return TestingHelper.templatesTestingNamespace; } }
        public static INamespace TemplatesTestingFrameworkNamespace {get { if (TestingHelper.templatesTestingFrameworkNamespace == null) TestingHelper.templatesTestingFrameworkNamespace = new TemplateNamespace("Templates.Testing.Framework"); return TestingHelper.templatesTestingFrameworkNamespace; } }

        public static IList<string> DebugProperty(ISpecificationProperty property)
        {
            IList<string> linesToWrite = new List<string>();

            linesToWrite.Add(string.Empty);
            linesToWrite.Add("//Property: Name = " + property.Name + "; " +
                "Property Type = " + property.PropertyType + "; " +
                "Is List? = " + property.IsList + "; " +
                "Required = " + property.Required + "; ");

            if (property.Minimum != null)
                linesToWrite.Add("Minimum = " + property.Minimum + "; ");
            else
                linesToWrite.Add("Minimum = null; ");

            if (property.Maximum != null)
                linesToWrite.Add("Maximum = " + property.Maximum + "; ");
            else
                linesToWrite.Add("Maximum = null; ");

            return linesToWrite;
        }

        public static IList<string> DebugSpecificationModel(ISpecificationModel model)
        {
            IList<string> linesToWrite = new List<string>();

            linesToWrite.Add(string.Empty);
            linesToWrite.Add("//SpecificationModel: " + model.Interface.VariableType.Name + " " + model.Variable.InstanceName + " = new " + model.Variable.VariableType.Name + "();");
            linesToWrite.Add("//  Repository: " + model.RepositoryInterface.VariableType.Name + " " + model.RepositoryVariable.InstanceName + " = new " + model.RepositoryVariable.VariableType.Name + "();");
            linesToWrite.Add("//  Service: " + model.ServiceInterface.VariableType.Name + " " + model.ServiceVariable.InstanceName + " = new " + model.ServiceVariable.VariableType.Name + "();");
            linesToWrite.Add("//");
            linesToWrite.Add("//Properties");

            foreach (ISpecificationProperty property in model.SpecificationProperties.Values)
                foreach (string line in DebugProperty(property))
                    linesToWrite.Add("  " + line);

            return linesToWrite;
        }

        public static IList<string> DebugSpecificationModels(string label, IList<ISpecificationModel> models)
        {
            IList<string> linesToWrite = new List<string>();

            linesToWrite.Add(string.Empty);
            linesToWrite.Add("//" + label);
            linesToWrite.Add("////List of Specification Models");
            linesToWrite.Add("//");

            foreach (ISpecificationModel model in models)
            {
                linesToWrite.Add("//SpecificationModel: " + model.Interface.VariableType.Name + " " + model.Variable.InstanceName + " = new " + model.Variable.VariableType.Name + "();");
                linesToWrite.Add("//  Repository: " + model.RepositoryInterface.VariableType.Name + " " + model.RepositoryVariable.InstanceName + " = new " + model.RepositoryVariable.VariableType.Name + "();");
                linesToWrite.Add("//  Service: " + model.ServiceInterface.VariableType.Name + " " + model.ServiceVariable.InstanceName + " = new " + model.ServiceVariable.VariableType.Name + "();");
            }

            return linesToWrite;
        }

        public static string InitializeVariable(string _type, string variable, string value)
        {
            return new StringBuilder().Append(_type).Append(" ").Append(variable).Append(" = ").Append(value).Append(";").ToString();
        }

        public static string ListOutKeyProperties(ISpecificationKey key)
        {
            return TestingHelper.ListOutKeyProperties(string.Empty, key);
        }

        public static string ListOutKeyProperties(string prefix, ISpecificationKey key)
        {
            string propertiesListed = string.Empty;

            if (key != null)
            {
                for (int i = 0; i < key.SpecificationProperties.Count; i++)
                {
                    if (i > 0)
                        propertiesListed += ", ";

                    if (!string.IsNullOrEmpty(prefix))
                        propertiesListed += prefix + key.SpecificationProperties[i].Name;
                    else
                        propertiesListed += key.SpecificationProperties[i].InstanceName;
                }
            }

            return propertiesListed;
        }

        public static string ListOutKeyProperties(ISpecificationModel model)
        {
            return TestingHelper.ListOutKeyProperties(null, model);
        }

        public static string ListOutKeyProperties(string prefix, ISpecificationModel model)
        {
            string propertiesListed = string.Empty;

            if (model != null && model.Key != null)
                propertiesListed = TestingHelper.ListOutKeyProperties(prefix, model.Key);

            return propertiesListed;
        }

        public static string ListOutPropertyTypes(string prefix, IEnumerable<ISpecificationProperty> properties, string suffix)
        {
            string propertyTypesListed = string.Empty;

            int count = 0;
            foreach (ISpecificationProperty property in properties)
            {
                if (count++ > 0)
                    propertyTypesListed += ", ";

                propertyTypesListed += prefix + property.PropertyType + suffix;
            }
            
            return propertyTypesListed;
        }

        public static string ListOutKeys(IEnumerable<IKey> keys)
        {
            StringBuilder keysListed = new StringBuilder();

            int count = 0;
            foreach (IKey key in keys)
            {
                if (count++ > 0)
                    keysListed.Append("; ");

                keysListed.Append(key.ToString());
            }

            return keysListed.ToString();
        }
        
        public static string MockOf(ISpecificationModel model)
        {
            return "Mock<" + model.Interface.VariableType.Name + ">";
        }

        public static string MockOf(IVariableType _type)
        {
            return "Mock<" + _type.Name + ">";
        }

        public static string MockOutProperty(ISpecification specification, ISpecificationModel modelUnderTest, ModelComponent component, ISpecificationKey key, ISpecificationProperty specificationProperty, string referenceName)
        {
            string _value = null;
            if (component == ModelComponent.Model && specificationProperty.PropertyType == modelUnderTest.Interface.VariableType.Name)
                _value = RandomValue(specification, specificationProperty, false, false);
            else
                _value = RandomValue(specification, specificationProperty, true, false);
            
            if (specificationProperty.Relationship != null)
                return MockOutProperty(key.InstanceName, specificationProperty.Name, referenceName, specificationProperty.PropertyType, "() => { return " + _value + "; }");

            return MockOutProperty(key.InstanceName, specificationProperty.Name, referenceName, specificationProperty.PropertyType, _value);
        }

        public static string MockOutProperty(ISpecification specification, ISpecificationModel modelUnderTest, ModelComponent component, ISpecificationModel model, ISpecificationProperty specificationProperty, string referenceName)
        {
            string _value = null;
            if (component == ModelComponent.Model && specificationProperty.PropertyType == modelUnderTest.Interface.VariableType.Name)
                _value = RandomValue(specification, specificationProperty, false, false);
            else
                _value = RandomValue(specification, specificationProperty, true, false);

            if (specificationProperty.Relationship != null)
                return MockOutProperty(model.Variable.InstanceName, specificationProperty.Name, referenceName, specificationProperty.PropertyType, "() => { return " + _value + "; }");

            return MockOutProperty(model.Variable.InstanceName, specificationProperty.Name, referenceName, specificationProperty.PropertyType, _value);
        }

        public static string MockOutProperty(ISpecification specification, ISpecificationModel modelUnderTest, ModelComponent component, string variable, ISpecificationProperty specificationProperty, string referenceName)
        {
            string _value = null;
            if (component == ModelComponent.Model && specificationProperty.PropertyType == modelUnderTest.Interface.VariableType.Name)
                _value = RandomValue(specification, specificationProperty, false, false);
            else
            _value = RandomValue(specification, specificationProperty, true, false);

            if (specificationProperty.Relationship != null)
                return MockOutProperty(variable, specificationProperty.Name, referenceName, specificationProperty.PropertyType, "() => { return " + _value + "; }");

            return MockOutProperty(variable, specificationProperty.Name, referenceName, specificationProperty.PropertyType, _value);
        }

        public static string MockOutProperty(string variable, string propertyName, string referenceName, string _type, string value)
        {
            return new StringBuilder().Append("this.").Append(variable).Append(".Setup(")
                .Append(referenceName).Append(" => ").Append(referenceName).Append(".").Append(propertyName).Append(")")
                .Append(".Returns(").Append(value == null ? "(" + _type + ")null" : value).Append(");")
                .ToString();
        }

        public static string NewMockOf(ISpecificationModel model)
        {
            return "new " + MockOf(model) + "()";
        }

        public static string NewMockOf(IVariableType _type)
        {
            return "new " + MockOf(_type) + "()";
        }

        public static string Pluralize(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return value;

            if (value.EndsWith("ey"))
                return value + "s";
            else if (value.EndsWith("y"))
                return value.Substring(0, value.Length - 1) + "ies";
            else if (value.EndsWith("ss"))
                return value + "es";
            else if (value.EndsWith("s"))
                return value;
            else
                return value + "s";
        }

        public static double RandomDouble(ISpecificationProperty specificationProperty)
        {
            if (specificationProperty.PropertyType != "double" && specificationProperty.PropertyType != "double?")
                throw new ArgumentException("Specification Property " + specificationProperty.Name + " is not an double!");

            double randomDouble;

            if (specificationProperty.Minimum == null && specificationProperty.Maximum == null)
                randomDouble = TemplatesHelper.RandomDouble(-100d, 100d);
            else if (specificationProperty.Minimum == null)
                randomDouble = TemplatesHelper.RandomDouble(-100d, (double)specificationProperty.Maximum);
            else if (specificationProperty.Maximum == null)
                randomDouble = TemplatesHelper.RandomDouble((double)specificationProperty.Minimum, 100d);
            else
                randomDouble = TemplatesHelper.RandomDouble((double)specificationProperty.Minimum, (double)specificationProperty.Maximum);

            if (specificationProperty.MantissaSize != null)
                randomDouble = Math.Round(randomDouble, specificationProperty.MantissaSize.Value);

            return randomDouble;
        }

        public static int RandomInt(ISpecificationProperty specificationProperty)
        {
            if (specificationProperty.PropertyType != "int" && specificationProperty.PropertyType != "int?")
                throw new ArgumentException("Specification Property " + specificationProperty.Name + " is not an integer!");

            int randomInt;

            if (specificationProperty.Minimum == null && specificationProperty.Maximum == null)
                randomInt = TemplatesHelper.RandomInt(int.MinValue, int.MaxValue);
            else if (specificationProperty.Minimum == null)
                randomInt = TemplatesHelper.RandomInt(int.MinValue, (int)specificationProperty.Maximum);
            else if (specificationProperty.Maximum == null)
                randomInt = TemplatesHelper.RandomInt((int)specificationProperty.Minimum, int.MaxValue);
            else
                randomInt = TemplatesHelper.RandomInt((int)specificationProperty.Minimum, (int)specificationProperty.Maximum);

            return randomInt;
        }

        public static string RandomString(ISpecificationProperty specificationProperty)
        {
            if (specificationProperty.PropertyType != "string")
                throw new ArgumentException("Specification Property " + specificationProperty.Name + " is not an string!");

            if (specificationProperty.Name.ToLower().Contains("number"))
            {
                int digits = 0;

                digits = specificationProperty.Minimum == null ? 0 : ((int?)specificationProperty.Minimum).Value > 6 ? 6 : ((int?)specificationProperty.Minimum).Value;
                int minimum = Convert.ToInt32(Math.Pow(10, digits)) - 1;

                digits = ((int?)specificationProperty.Maximum).Value > 6 ? 6 : ((int?)specificationProperty.Maximum).Value;
                int maximum = Convert.ToInt32(Math.Pow(10, digits)) - 1;

                return TemplatesHelper.RandomInt(minimum, maximum).ToString();
            }

            return TemplatesHelper.RandomString((int)specificationProperty.Maximum);
        }
        
        public static string RandomValue(ISpecification specification, ISpecificationProperty specificationProperty)
        {
            return RandomValue(specification, specificationProperty, false, true);
        }

        public static string RandomValue(ISpecification specification, ISpecificationProperty specificationProperty, bool usingMocks, bool useNullForDefault)
        {
            if (specificationProperty.Relationship != null && specificationProperty.Relationship.RelatedModel != null)
            {
                ISpecificationModel relatedModel = specificationProperty.Relationship.RelatedModel;
                
                if (usingMocks)
                {
                    if (specificationProperty.IsList)
                        return "this." + relatedModel.Variable.ListInstanceName + ".Select(_mock => _mock.Object).ToList()";
                    else
                        return "this." + relatedModel.Variable.InstanceName + ".Object";
                }
                else
                {
                    if (specificationProperty.IsList)
                        return TemplatesHelper.NewOf(TemplatesHelper.ListOf(relatedModel.Interface.VariableType));
                    else if(useNullForDefault)
                        return "null";
                    else
                        return "this." + relatedModel.Variable.InstanceName;
                }
            }

            if (specification.Enumerations.Values.Any(_enumeration => _enumeration.Name == specificationProperty.PropertyType))
            {
                ISpecificationEnumeration specificationEnumeration = specification.Enumerations.Values.First(_enumeration => _enumeration.Name == specificationProperty.PropertyType);

                IEnumeration enumeration = new TemplateEnumeration(specification.Settings.FrameworkNamespace, specificationEnumeration.Name);
                foreach (ISpecificationEnumerationItem item in specificationEnumeration.Items)
                    enumeration.Add(new TemplateEnumerationItem(item.Name));

                return TemplatesHelper.FormatEnumeration(TemplatesHelper.RandomEnumerationItem(enumeration));
            }

            if (specificationProperty.PropertyType == "bool" || specificationProperty.PropertyType == "bool?")
                return TemplatesHelper.FormatBool(true);
            if (specificationProperty.PropertyType == "DateTime" || specificationProperty.PropertyType == "DateTime?")
                return TemplatesHelper.FormatDateTime(specificationProperty.IsDateOnly ? DateTime.Now.Date : DateTime.Now);
            if (specificationProperty.PropertyType == "double" || specificationProperty.PropertyType == "double?")
                return TemplatesHelper.FormatDouble(TestingHelper.RandomDouble(specificationProperty));
            if (specificationProperty.PropertyType == "Guid" || specificationProperty.PropertyType == "Guid?")
                return "Guid.NewGuid()";
            if (specificationProperty.PropertyType == "int" || specificationProperty.PropertyType == "int?")
                return TemplatesHelper.FormatInt(TestingHelper.RandomInt(specificationProperty));
            if (specificationProperty.PropertyType == "string")
                return TemplatesHelper.FormatString(TestingHelper.RandomString(specificationProperty));
            if (specificationProperty.PropertyType == "TimeSpan" || specificationProperty.PropertyType == "TimeSpan?")
                return TemplatesHelper.FormatTimeSpan(TemplatesHelper.RandomTimeSpan());

            return TemplatesHelper.FormatString("Unsupported type: " + specificationProperty.PropertyType);
        }

        public static string SetProperty(ISpecification specification, ISpecificationModel specificationModel, ISpecificationProperty specificationProperty)
        {
            return SetProperty(specificationModel.Variable.InstanceName, specificationProperty.Name, RandomValue(specification, specificationProperty));
        }

        public static string SetProperty(string variable, string property, string value)
        {
            return new StringBuilder().Append(variable).Append(".").Append(property).Append(" = ").Append(value).Append(";").ToString();
        }
    }
}
