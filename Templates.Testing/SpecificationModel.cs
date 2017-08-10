using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Templates.Framework;
using Templates.Testing.Framework;

namespace Templates.Testing
{
    public class SpecificationModel : ISpecificationModel
    {
        protected static string GenericSearchReference = "search";
        protected static string Repository = "Repository";
        protected static string Search = "Search";
        protected static string Service = "Service";

        protected IList<IAdmire> admires;
        protected IList<IAdoptedChild> adoptedChildren;
        protected IList<IAdoptingParent> adoptingParents;
        protected IList<ISpecificationModel> affectedModels;
        protected IList<IAssociated> associates;
        protected IList<IBiologicalChild> biologicalChildren;
        protected IList<IBiologicalParent> biologicalParents;
        protected bool canDelete;
        protected bool canInsert;
        protected bool canUpdate;
        protected IList<IChild> children;
        protected IList<IRelationship> closeRelationships;
        protected IList<ICustodiedChild> custodiedChildren;
        protected IList<ISpecificationModel> dependants;
        protected IList<IRelationship> directlyAffectedRelationships;
        protected IList<IRelationship> directlyDepandantRelationships;
        protected IList<IDivorce> divorces;
        protected IList<IEnemy> enemies;
        protected IList<IFosterChild> fosterChildren;
        protected IList<IFosterParent> fosterParents;
        protected IList<IFriend> friends;
        protected IList<ISpecificationModel> guardians;
        protected IList<IGodchild> godchildren;
        protected IList<IGodfather> godfathers;
        protected IList<IGrandchild> grandchildren;
        protected IList<IGrandparent> grandparents;
        protected bool hasRepositoryAndService;
        protected IList<IIllegitimateChild> illegitimateChildren;
        protected IList<IIllegitimateParent> illegitimateParents;
        protected IVariable _interface;
        protected bool isReadOnly;
        protected IVariable keyInterface;
        protected IVariable keyVariable;
        protected ISpecificationKey key;
        protected IList<IMarriage> marriages;
        protected IList<IRelationship> monitoredRelationships;
        protected IList<IOnlyChild> onlyChildren;
        protected IList<IRelationship> ownedRelationships;
        protected IList<IVariable> parameter;
        protected IList<IParent> parents;
        protected IList<IRecursive> recursive;
        protected IList<IRelationship> relationships;
        protected IList<IRelationship> relationshipsRequiredForIntegrationTesting;
        protected IList<IRelationship> relationshipsRequiredForUnitTesting;
        protected IList<IRelationship> relationshipsToDelete;
        protected IList<IRelationship> relationshipsToFind;
        protected IList<IRelationship> relationshipsToManage;
        protected IList<IRelationship> relationshipsToNotDelete;
        protected IList<IRelationship> relationshipsToNotFind;
        protected IList<IRelationship> relationshipsToNotFindOnFindSingle;
        protected IList<IRelationship> relationshipsToNotManage;
        protected IList<IVariable> repositoryParameter;
        protected IVariable repositoryInterface;
        protected IVariable repositoryVariable;
        protected IVariable searchMultipleInterface;
        protected IVariable searchMultipleVariable;
        protected IVariable searchInterface;
        protected IVariable searchVariable;
        protected IList<ISeperated> seperations;
        protected IVariable serviceInterface;
        protected IVariable serviceVariable;
        protected IList<ISibling> siblings;
        protected IList<ISignificantOther> significantOthers;
        protected IList<ISingleParent> singleParents;
        protected ISpecification specification;
        protected Dictionary<string, ISpecificationProperty> specificationProperties;
        protected ITestingFactory testingFactory;
        protected Tier tier;
        protected IList<IUnfitParent> unfitParents;
        protected IVariable variable;

        public IList<IAdmire> Admires { get { return this.admires; } }
        public IList<IAdoptedChild> AdoptedChildren { get { return this.adoptedChildren; } }
        public IList<IAdoptingParent> AdoptingParents { get { return this.adoptingParents; } }
        public IList<ISpecificationModel> AffectedModels { get { if (this.affectedModels == null) this.affectedModels = FindAffectedModels(new List<ISpecificationModel>()); return this.affectedModels; } }
        public IList<IAssociated> Associates { get { return this.associates; } }
        public IList<IBiologicalChild> BiologicalChildren { get { return this.biologicalChildren; } }
        public IList<IBiologicalParent> BiologicalParents { get { return this.biologicalParents; } }
        public bool CanDelete { get { return this.canDelete; } set { this.canDelete = value; } }
        public bool CanInsert { get { return this.canInsert; } set { this.canInsert = value; } }
        public bool CanUpdate { get { return this.canUpdate; } set { this.canUpdate = value; } }
        public IList<IChild> Children { get { return this.children; } }
        public IList<ICustodiedChild> CustodiedChildren { get { return this.custodiedChildren; } }
        public IList<ISpecificationModel> Dependants { get { if (this.dependants == null) this.dependants = FindDependants(new List<ISpecificationModel>()); return this.dependants; } }
        public IList<IDivorce> Divorces { get { return this.divorces; } }
        public IList<IEnemy> Enemies { get { return this.enemies; } }
        public IList<IFosterChild> FosterChildren { get { return this.fosterChildren; } }
        public IList<IFosterParent> FosterParents { get { return this.fosterParents; } }
        public IList<IFriend> Friends { get { return this.friends; } }
        public IList<IGodchild> Godchildren { get { return this.godchildren; } }
        public IList<IGodfather> Godfathers { get { return this.godfathers; } }
        public IList<IGrandchild> Grandchildren { get { return this.grandchildren; } }
        public IList<IGrandparent> Grandparents { get { return this.grandparents; } }
        public IList<ISpecificationModel> Guardians { get { if (this.guardians == null) this.guardians = FindGuardians(new List<ISpecificationModel>()); return this.guardians; } }
        public bool HasRepositoryAndService { get { return this.hasRepositoryAndService; } set { this.hasRepositoryAndService = value; } }
        public IList<IIllegitimateChild> IllegitimateChildren { get { return this.illegitimateChildren; } }
        public IList<IIllegitimateParent> IllegitimateParents { get { return this.illegitimateParents; } }
        public IVariable Interface { get { return this._interface; } set { this._interface = value; } }
        public bool ReadOnly { get { return this.isReadOnly; } set { this.isReadOnly = value; } }
        public ISpecificationKey Key { get { return this.key; } set { this.key = value; } }
        public IVariable KeyInterface { get { return this.keyInterface; } set { this.keyInterface = value; } }
        public IVariable KeyVariable { get { return this.keyVariable; } set { this.keyVariable = value; } }
        public IList<IMarriage> Marriages { get { return this.marriages; } }
        public IList<IOnlyChild> OnlyChildren { get { return this.onlyChildren; } }
        public IList<IVariable> Parameter { get { if (this.parameter == null) this.parameter = new List<IVariable>() { Interface }; return this.parameter; } }
        public IList<IParent> Parents { get { return this.parents; } }
        public IList<IRecursive> Recursive { get { return this.recursive; } }
        public IList<IRelationship> Relationships { get { return this.relationships; } }
        public IList<IVariable> RepositoryParameter { get { if (this.repositoryParameter == null) this.repositoryParameter = new List<IVariable>() { RepositoryVariable }; return this.repositoryParameter; } set { this.repositoryParameter = value; } }
        public IVariable RepositoryInterface { get { return this.repositoryInterface; } set { this.repositoryInterface = value; } }
        public IVariable RepositoryVariable { get { return this.repositoryVariable; } set { this.repositoryVariable = value; } }
        public IVariable SearchMultipleInterface { get { return this.searchMultipleInterface; } set { this.searchMultipleInterface = value; } }
        public IVariable SearchMultipleVariable { get { return this.searchMultipleVariable; } set { this.searchMultipleVariable = value; } }
        public IVariable SearchInterface { get { return this.searchInterface; } set { this.searchInterface = value; } }
        public IVariable SearchVariable { get { return this.searchVariable; } set { this.searchVariable = value; } }
        public IList<ISeperated> Seperations { get { return this.seperations; } }
        public IVariable ServiceInterface { get { return this.serviceInterface; } set { this.serviceInterface = value; } }
        public IVariable ServiceVariable { get { return this.serviceVariable; } set { this.serviceVariable = value; } }
        public IList<ISibling> Siblings { get { return this.siblings; } }
        public IList<ISignificantOther> SignificantOthers { get { return this.significantOthers; } }
        public IList<ISingleParent> SingleParents { get { return this.singleParents; } }
        public Dictionary<string, ISpecificationProperty> SpecificationProperties { get { return this.specificationProperties; } set { this.specificationProperties = value; } }
        public Tier Tier { get { return this.tier; } set { this.tier = value; } }
        public IList<IUnfitParent> UnfitParents { get { return this.unfitParents; } }
        public IVariable Variable { get { return this.variable; } set { this.variable = value; } }

        public IList<IRelationship> CloseRelationships
        {
            get
            {
                if (this.closeRelationships == null)
                {
                    this.closeRelationships = new List<IRelationship>();

                    foreach (IRelationship relationship in Relationships)
                        if (relationship is IAdmire || relationship is IBiologicalChild)
                            this.closeRelationships.Add(relationship);
                }

                return this.closeRelationships;
            }
        }
        public IList<IRelationship> DirectlyAffectedRelationships
        {
            get
            {
                if (this.directlyAffectedRelationships == null)
                {
                    this.directlyAffectedRelationships = new List<IRelationship>();

                    foreach (IRelationship relationship in Relationships)
                        if (relationship.RelatedModel.HasRepositoryAndService
                            && (relationship is IAdmire
                                || relationship is IAdoptedChild
                                || relationship is IAdoptingParent
                                || relationship is IBiologicalChild
                                || relationship is IBiologicalParent
                                || relationship is IFriend
                                || relationship is IIllegitimateChild
                            ))
                        {
                            this.directlyAffectedRelationships.Add(relationship);
                        }
                }

                return this.directlyAffectedRelationships;
            }
        }
        public IList<IRelationship> DirectlyDepandantRelationships
        {
            get
            {
                if (this.directlyDepandantRelationships == null)
                {
                    this.directlyDepandantRelationships = new List<IRelationship>();
                    IEnumerable<IRelationship> matchedRelationships = null;

                    if (tier == Tier.Primary || tier == Tier.Secondary)
                    {
                        matchedRelationships = Relationships
                            .Where(_relationship => _relationship.RelatedModel.HasRepositoryAndService
                                                    && !(_relationship is IEnemy)
                                                    && !(_relationship is IRecursive)
                                                    && !(_relationship is ISibling)
                                                    && !(_relationship is ISignificantOther))
                            .OrderBy(_relationship => _relationship.RelatedModel.Variable.Reference);
                    }
                    else
                    {
                        matchedRelationships = Relationships
                            .Where(_relationship => _relationship.RelatedModel.HasRepositoryAndService
                                                    && _relationship is IGrandparent)
                            .OrderBy(_relationship => _relationship.RelatedModel.Variable.Reference);
                    }

                    foreach (IRelationship relationship in matchedRelationships)
                        this.directlyDepandantRelationships.Add(relationship);
                }

                return this.directlyDepandantRelationships;
            }
        }
        public IList<IRelationship> MonitoredRelationships
        {
            get
            {
                if (this.monitoredRelationships == null)
                {
                    this.monitoredRelationships = new List<IRelationship>();

                    foreach (IRelationship relationship in Relationships)
                        if (relationship.ReferencingProperty != null && relationship is IAdmire)
                            this.monitoredRelationships.Add(relationship);
                }

                return this.monitoredRelationships;
            }
        }
        public IList<IRelationship> OwnedRelationships
        {
            get
            {
                if (this.ownedRelationships == null)
                {
                    this.ownedRelationships = new List<IRelationship>();

                    foreach (IRelationship relationship in Relationships)
                        if (relationship.ReferencingProperty != null && relationship.ReferencingProperty.IsList && relationship is IAdmire)
                            this.ownedRelationships.Add(relationship);
                }

                return this.ownedRelationships;
            }
        }
        public IList<IRelationship> RelationshipsRequiredForIntegrationTesting
        {
            get
            {
                if (this.relationshipsRequiredForIntegrationTesting == null)
                {
                    this.relationshipsRequiredForIntegrationTesting = new List<IRelationship>();

                    foreach (IRelationship relationship in Relationships)
                        if (relationship is IBiologicalChild 
                                || relationship is IBiologicalParent
                                || relationship is IFosterChild
                                || relationship is IFosterParent
                              //|| relationship is IGrandchild
                              //|| relationship is IGrandparent
                                || relationship is IOnlyChild
                                || relationship is ISingleParent
                                || relationship is IUnfitParent)
                            this.relationshipsRequiredForIntegrationTesting.Add(relationship);
                }

                return this.relationshipsRequiredForIntegrationTesting;
            }
        }
        public IList<IRelationship> RelationshipsRequiredForUnitTesting
        {
            get
            {
                if (this.relationshipsRequiredForUnitTesting == null)
                {
                    this.relationshipsRequiredForUnitTesting = new List<IRelationship>();

                    foreach (IRelationship relationship in Relationships)
                        if (relationship is IAdmire
                                || relationship is IAdoptedChild
                                || relationship is IAdoptingParent
                                || relationship is IBiologicalChild
                                || relationship is IBiologicalParent
                                || relationship is IFosterChild
                                || relationship is IFosterParent
                                || relationship is IFriend
                                || relationship is IOnlyChild
                                || relationship is IGodchild
                                || relationship is IGodfather
                                || relationship is IGrandchild
                                || relationship is IGrandparent
                                || relationship is ISingleParent
                                || relationship is IUnfitParent)
                            this.relationshipsRequiredForUnitTesting.Add(relationship);
                }

                return this.relationshipsRequiredForUnitTesting;
            }
        }
        public IList<IRelationship> RelationshipsToDelete
        {
            get
            {
                if (this.relationshipsToDelete == null)
                {
                    this.relationshipsToDelete = new List<IRelationship>();

                    foreach (IRelationship relationship in Relationships)
                        if (relationship.RelatedModel.HasRepositoryAndService
                            && (relationship is IBiologicalChild))
                            this.relationshipsToDelete.Add(relationship);
                }

                return this.relationshipsToDelete;
            }
        }
        public IList<IRelationship> RelationshipsToFind
        {
            get
            {
                if (this.relationshipsToFind == null)
                {
                    this.relationshipsToFind = new List<IRelationship>();

                    foreach (IRelationship relationship in Relationships)
                        if (relationship.RelatedModel.HasRepositoryAndService
                            && ((relationship is IAdmire && relationship.ReferencingProperty.IsList)
                                || relationship is IBiologicalChild
                                || relationship is IFosterChild))
                            this.relationshipsToFind.Add(relationship);
                }

                return this.relationshipsToFind;
            }
        }
        public IList<IRelationship> RelationshipsToManage
        {
            get
            {
                if (this.relationshipsToManage == null)
                {
                    this.relationshipsToManage = new List<IRelationship>();

                    foreach (IRelationship relationship in Relationships)
                        if (relationship.RelatedModel.HasRepositoryAndService
                            && relationship is IBiologicalChild)
                            this.relationshipsToManage.Add(relationship);
                }

                return this.relationshipsToManage;
            }
        }
        public IList<IRelationship> RelationshipsToNotDelete
        {
            get
            {
                if (this.relationshipsToNotDelete == null)
                {
                    this.relationshipsToNotDelete = new List<IRelationship>();

                    foreach (IRelationship relationship in Relationships)
                        if (relationship.RelatedModel.HasRepositoryAndService
                            && (relationship is IAdmire
                                || relationship is IAdoptedChild
                                || relationship is IAdoptingParent
                                || relationship is IBiologicalParent))
                            this.relationshipsToNotDelete.Add(relationship);
                }

                return this.relationshipsToNotDelete;
            }
        }
        public IList<IRelationship> RelationshipsToNotFind
        {
            get
            {
                if (this.relationshipsToNotFind == null)
                {
                    this.relationshipsToNotFind = new List<IRelationship>();

                    foreach (IRelationship relationship in Relationships)
                        if (relationship.RelatedModel.HasRepositoryAndService
                            && (relationship is IAdmire
                                || relationship is IBiologicalChild
                                || relationship is IBiologicalParent))
                            this.relationshipsToNotFind.Add(relationship);
                }

                return this.relationshipsToNotFind;
            }
        }
        public IList<IRelationship> RelationshipsToNotFindOnFindSingle
        {
            get
            {
                if (this.relationshipsToNotFindOnFindSingle == null)
                {
                    Dictionary<string, IRelationship> temp = new Dictionary<string, IRelationship>();
                    
                    foreach (IRelationship relationship in Relationships)
                        if (relationship.RelatedModel.HasRepositoryAndService
                            && (relationship is IBiologicalParent
                                || relationship is IFosterParent
                                || relationship is ISingleParent)
                            && !temp.ContainsKey(relationship.RelatedModel.Interface.VariableType.Name))
                            temp[relationship.RelatedModel.Interface.VariableType.Name] = relationship;

                    this.relationshipsToNotFindOnFindSingle = temp.Values.OrderBy(_relationship => _relationship.RelatedModel.Variable.Reference).ToList();
                }

                return this.relationshipsToNotFindOnFindSingle;
            }
        }
        public IList<IRelationship> RelationshipsToNotManage
        {
            get
            {
                if (this.relationshipsToNotManage == null)
                {
                    this.relationshipsToNotManage = new List<IRelationship>();

                    foreach (IRelationship relationship in Relationships)
                        if (relationship.RelatedModel.HasRepositoryAndService
                            && (relationship is IBiologicalParent))
                            this.relationshipsToNotManage.Add(relationship);
                }

                return this.relationshipsToNotManage;
            }
        }

        public SpecificationModel(ISpecification specification, ITestingFactory testingFactory, string name)
        {
            name = name.Substring(0, 1).ToUpper() + name.Substring(1, name.Length - 1);

            this._interface = new TemplateVariable("I" + name, name);
            this.testingFactory = testingFactory;
            this.tier = Tier.Primary;
            this.variable = new TemplateVariable(name);

            string keyName = Variable.VariableType.Name + "Key";
            this.keyInterface = new TemplateVariable("I" + keyName, keyName);
            this.keyVariable = new TemplateVariable(keyName);

            string searchMultipleName = Variable.ListInstanceNameReference + SpecificationModel.Search;
            this.searchMultipleInterface = new TemplateVariable("I" + searchMultipleName, searchMultipleName);
            this.searchMultipleVariable = new TemplateVariable(searchMultipleName);

            string searchName = Variable.VariableType.Name + SpecificationModel.Search;
            this.searchInterface = new TemplateVariable("I" + searchName, searchName);
            this.searchVariable = new TemplateVariable(searchName);

            string repositoryName = Variable.VariableType.Name + SpecificationModel.Repository;
            this.repositoryInterface = new TemplateVariable("I" + repositoryName, repositoryName);
            this.repositoryVariable = new TemplateVariable(repositoryName);

            string serviceName = Variable.VariableType.Name + SpecificationModel.Service;
            this.serviceInterface = new TemplateVariable("I" + serviceName, serviceName);
            this.serviceVariable = new TemplateVariable(serviceName);

            this.admires = new List<IAdmire>();
            this.adoptedChildren = new List<IAdoptedChild>();
            this.adoptingParents = new List<IAdoptingParent>();
            this.associates = new List<IAssociated>();
            this.biologicalChildren = new List<IBiologicalChild>();
            this.biologicalParents = new List<IBiologicalParent>();
            this.children = new List<IChild>();
            this.custodiedChildren = new List<ICustodiedChild>();
            this.divorces = new List<IDivorce>();
            this.enemies = new List<IEnemy>();
            this.fosterChildren = new List<IFosterChild>();
            this.fosterParents = new List<IFosterParent>();
            this.friends = new List<IFriend>();
            this.godchildren = new List<IGodchild>();
            this.godfathers = new List<IGodfather>();
            this.grandchildren = new List<IGrandchild>();
            this.grandparents = new List<IGrandparent>();
            this.isReadOnly = false;
            this.illegitimateChildren = new List<IIllegitimateChild>();
            this.illegitimateParents = new List<IIllegitimateParent>();
            this.marriages = new List<IMarriage>();
            this.onlyChildren = new List<IOnlyChild>();
            this.parents = new List<IParent>();
            this.recursive = new List<IRecursive>();
            this.relationships = new List<IRelationship>();
            this.seperations = new List<ISeperated>();
            this.siblings = new List<ISibling>();
            this.significantOthers = new List<ISignificantOther>();
            this.singleParents = new List<ISingleParent>();
            this.specificationProperties = new Dictionary<string, ISpecificationProperty>();
            this.unfitParents = new List<IUnfitParent>();
        }
        
        

        public void SetupReciprocatedRelationship(ISpecificationModel relatedModel, IRelationship reciprocatedRelationship)
        {
            if (reciprocatedRelationship is IAdmire)
            {
                IEnemy enemy = this.testingFactory.GenerateEnemy(this, relatedModel, reciprocatedRelationship.ReferencingProperty);

                this.associates.Add(enemy);
                this.enemies.Add(enemy);
                this.relationships.Add(enemy);
            }
            else if (reciprocatedRelationship is IGodchild)
            {
                IGodfather godfather = this.testingFactory.GenerateGodfather(this, relatedModel, reciprocatedRelationship.ReferencingProperty);

                this.godfathers.Add(godfather);
                this.parents.Add(godfather);
                this.relationships.Add(godfather);
            }
            else if (reciprocatedRelationship is IGrandchild)
            {
                IGrandparent grandparent = this.testingFactory.GenerateGrandparent(this, relatedModel, reciprocatedRelationship.ReferencingProperty);

                this.grandparents.Add(grandparent);
                this.parents.Add(grandparent);
                this.relationships.Add(grandparent);
            }
            else if (reciprocatedRelationship is IUnfitParent)
            {
                ICustodiedChild custodiedChild = this.testingFactory.GenerateCustodiedChild(this, relatedModel, reciprocatedRelationship.ReferencingProperty);

                this.children.Add(custodiedChild);
                this.custodiedChildren.Add(custodiedChild);
                this.relationships.Add(custodiedChild);
            }
            else
            {
                throw new NotImplementedException(new StringBuilder("Setup ").Append(relatedModel.Variable.VariableType.Name).Append("'s reciprocated relationship for property ").Append(reciprocatedRelationship.ReferencingProperty.Name).ToString());
            }
        }

        public void SetupRelationship(ISpecificationModel relatedModel)
        {
            IEnumerable<ISpecificationProperty> relatedSpecificationProperties = SpecificationProperties.Values.Concat(Key.SpecificationProperties).Where(_specificationProperty => _specificationProperty.PropertyType == relatedModel.Interface.VariableType.Name || _specificationProperty.PropertyType == relatedModel.Variable.VariableType.Name);

            foreach (ISpecificationProperty specificationProperty in relatedSpecificationProperties)
            {
                if (specificationProperty.PropertyType == Variable.VariableType.Name || specificationProperty.PropertyType == Interface.VariableType.Name)
                {
                    ISpecificationProperty otherReferencingProperty = SpecificationProperties.Values.Where(_property => _property.Name != specificationProperty.Name && (_property.PropertyType == Variable.VariableType.Name || _property.PropertyType == Variable.InstanceName)).FirstOrDefault();

                    IRecursive recursive = this.testingFactory.GenerateRecursive(specificationProperty);

                    this.recursive.Add(recursive);
                    this.relationships.Add(recursive);
                }
                else if (Tier == Tier.Tertiary || relatedModel.Tier == Tier.Tertiary)
                {
                    //ISpecificationProperty otherReferencingProperty = relatedModel.SpecificationProperties.Values.Where(_property => (_property.PropertyType == Variable.VariableType.Name || _property.PropertyType == Interface.VariableType.Name)).FirstOrDefault();

                    //if (otherReferencingProperty == null && relatedModel.Key != null)
                    //    otherReferencingProperty = relatedModel.Key.SpecificationProperties.Where(_property => (_property.PropertyType == Variable.VariableType.Name || _property.PropertyType == Interface.VariableType.Name)).FirstOrDefault();

                    if (Tier == Tier.Tertiary && relatedModel.Tier == Tier.Tertiary)
                    {
                        //relatedModel is my sibling
                    }
                    else if (Tier == Tier.Tertiary)
                    {
                        IGrandparent grandparent = this.testingFactory.GenerateGrandparent(specificationProperty, relatedModel);

                        this.grandparents.Add(grandparent);
                        this.parents.Add(grandparent);
                        this.relationships.Add(grandparent);
                    }
                    else // relatedModel.Tier equals Tier.Teriary
                    {
                        IGrandchild grandchild = this.testingFactory.GenerateGrandchild(specificationProperty, relatedModel);

                        this.grandchildren.Add(grandchild);
                        this.children.Add(grandchild);
                        this.relationships.Add(grandchild);
                    }
                }
                else
                {
                    ISpecificationProperty otherReferencingProperty = relatedModel.SpecificationProperties.Values.Where(_property => (_property.PropertyType == Variable.VariableType.Name || _property.PropertyType == Interface.VariableType.Name)).FirstOrDefault();

                    if (otherReferencingProperty == null && relatedModel.Key != null)
                        otherReferencingProperty = relatedModel.Key.SpecificationProperties.Where(_property => (_property.PropertyType == Variable.VariableType.Name || _property.PropertyType == Interface.VariableType.Name)).FirstOrDefault();

                    if (specificationProperty.IsKey || specificationProperty.Required)
                    {
                        if (otherReferencingProperty == null)
                        {
                            IUnfitParent unfitParent = this.testingFactory.GenerateUnfitParent(specificationProperty, relatedModel);

                            this.unfitParents.Add(unfitParent);
                            this.parents.Add(unfitParent);
                            this.relationships.Add(unfitParent);
                        }
                        else if (otherReferencingProperty.IsKey || otherReferencingProperty.Required)
                        {
                            throw new NotSupportedException("We currently don't support having two models reference each other as Keys or Required.  Only 1 needs to be a Key or Required.");
                        }
                        else if (otherReferencingProperty.IsList)
                        {
                            IFosterParent fosterParent =  this.testingFactory.GenerateFosterParent(specificationProperty, relatedModel);
                            
                            this.fosterParents.Add(fosterParent);
                            this.parents.Add(fosterParent);
                            this.relationships.Add(fosterParent);
                        }
                        else
                        {
                            ISingleParent singleParent = this.testingFactory.GenerateSingleParent(specificationProperty, relatedModel);

                            this.singleParents.Add(singleParent);
                            this.parents.Add(singleParent);
                            this.relationships.Add(singleParent);
                        }
                    }
                    else if (specificationProperty.IsList)
                    {
                        if (otherReferencingProperty == null)
                        {
                            IGodchild godchild = this.testingFactory.GenerateGodchild(specificationProperty, relatedModel);

                            this.godchildren.Add(godchild);
                            this.children.Add(godchild);
                            this.relationships.Add(godchild);
                        }
                        else if (otherReferencingProperty.IsKey || otherReferencingProperty.Required)
                        {
                            IFosterChild fosterChild = this.testingFactory.GenerateFosterChild(specificationProperty, relatedModel);

                            this.children.Add(fosterChild);
                            this.fosterChildren.Add(fosterChild);
                            this.relationships.Add(fosterChild);
                        }
                        else if (otherReferencingProperty.IsList)
                        {
                            IFriend friend = this.testingFactory.GenerateFriend(specificationProperty, relatedModel);
                            
                            this.associates.Add(friend);
                            this.friends.Add(friend);
                            this.relationships.Add(friend);
                        }
                        else
                        {
                            IAdoptedChild adoptedChild = this.testingFactory.GenerateAdoptedChild(specificationProperty, relatedModel);
                            
                            this.adoptedChildren.Add(adoptedChild);
                            this.children.Add(adoptedChild);
                            this.relationships.Add(adoptedChild);
                        }
                    }
                    else
                    {
                        if (otherReferencingProperty == null)
                        {
                            IAdmire admire = this.testingFactory.GenerateAdmire(specificationProperty, relatedModel);
                            
                            this.admires.Add(admire);
                            this.associates.Add(admire);
                            this.relationships.Add(admire);
                        }
                        else if (otherReferencingProperty.IsKey || otherReferencingProperty.Required)
                        {
                            IOnlyChild onlyChild = this.testingFactory.GenerateOnlyChild(specificationProperty, relatedModel);

                            this.children.Add(onlyChild);
                            this.onlyChildren.Add(onlyChild);
                            this.relationships.Add(onlyChild);
                        }
                        else if (otherReferencingProperty.IsList)
                        {
                            IAdoptingParent adoptingParent = this.testingFactory.GenerateAdoptingParent(specificationProperty, relatedModel);
                            
                            this.adoptingParents.Add(adoptingParent);
                            this.parents.Add(adoptingParent);
                            this.relationships.Add(adoptingParent);
                        }
                        else
                        {
                            IFriend friend = this.testingFactory.GenerateFriend(specificationProperty, relatedModel);

                            this.associates.Add(friend);
                            this.friends.Add(friend);
                            this.relationships.Add(friend);
                        }
                    }
                }
            }
        }

        public void SetupSiblingRelationship(ISpecificationModel relatedModel)
        {
            ISibling sibling = this.testingFactory.GenerateSibling(this, relatedModel);

            this.siblings.Add(sibling);
            this.relationships.Add(sibling);
        }

        public IList<ISpecificationModel> FindAffectedModels(IList<ISpecificationModel> modelsAlreadyChecked)
        {
            Dictionary<string, ISpecificationModel> affectedModels = new Dictionary<string, ISpecificationModel>();

            modelsAlreadyChecked.Add(this);

            foreach (IRelationship relationship in this.Relationships)
            {
                ISpecificationModel relatedModel = relationship.RelatedModel;

                if (!modelsAlreadyChecked.Contains(relatedModel)
                    && !affectedModels.ContainsKey(relatedModel.Variable.VariableType.Name)
                    && (relationship is IAdmire
                        || relationship is IAdoptedChild
                        || relationship is IAdoptingParent
                        || relationship is IBiologicalChild
                        || relationship is IBiologicalParent
                        || relationship is IFriend
                        || relationship is IIllegitimateChild
                    ))
                {
                    foreach (ISpecificationModel dependantModel in relatedModel.FindAffectedModels(modelsAlreadyChecked))
                        affectedModels[dependantModel.Variable.VariableType.Name] = dependantModel;

                    affectedModels[relatedModel.Variable.VariableType.Name] = relatedModel;
                }
            }

            return affectedModels.Values.ToList();
        }

        public IList<ISpecificationModel> FindDependants(IList<ISpecificationModel> modelsAlreadyChecked)
        {
            Dictionary<string, ISpecificationModel> dependantModels = new Dictionary<string, ISpecificationModel>();

            modelsAlreadyChecked.Add(this);

            foreach (IRelationship relationship in this.Relationships)
            {
                ISpecificationModel relatedModel = relationship.RelatedModel;

                if (!modelsAlreadyChecked.Contains(relatedModel)
                    && !dependantModels.ContainsKey(relatedModel.Variable.VariableType.Name)
                    && (relationship is IBiologicalChild || relationship is IBiologicalParent))
                {
                    foreach (ISpecificationModel dependantModel in relatedModel.FindDependants(modelsAlreadyChecked))
                        dependantModels[dependantModel.Variable.VariableType.Name] = dependantModel;

                    dependantModels[relatedModel.Variable.VariableType.Name] = relatedModel;
                }
            }

            return dependantModels.Values.ToList();
        }

        public IList<ISpecificationModel> FindGuardians(IList<ISpecificationModel> modelsAlreadyChecked)
        {
            Dictionary<string, ISpecificationModel> dependantModels = new Dictionary<string, ISpecificationModel>();

            modelsAlreadyChecked.Add(this);

            foreach (IRelationship relationship in this.Relationships)
            {
                ISpecificationModel relatedModel = relationship.RelatedModel;

                if (!modelsAlreadyChecked.Contains(relatedModel)
                    && !dependantModels.ContainsKey(relatedModel.Variable.VariableType.Name)
                    && (relationship is IBiologicalChild || relationship is IBiologicalParent))
                {
                    foreach (ISpecificationModel dependantModel in relatedModel.FindGuardians(modelsAlreadyChecked))
                        dependantModels[dependantModel.Variable.VariableType.Name] = dependantModel;

                    dependantModels[relatedModel.Variable.VariableType.Name] = relatedModel;
                }
            }

            return dependantModels.Values.ToList();
        }
    }
}
