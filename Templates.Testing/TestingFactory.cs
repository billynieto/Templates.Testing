using System;

using Templates.Testing.Framework;

namespace Templates.Testing
{
    public class TestingFactory : ITestingFactory
    {
        public IAdoptedChild GenerateAdoptedChild(ISpecificationProperty specificationProperty, ISpecificationModel relatedModel)
        {
            return new AdoptedChild(specificationProperty, relatedModel);
        }

        public IAdoptingParent GenerateAdoptingParent(ISpecificationProperty specificationProperty, ISpecificationModel relatedModel)
        {
            return new AdoptingParent(specificationProperty, relatedModel);
        }

        public IAdmire GenerateAdmire(ISpecificationProperty specificationProperty, ISpecificationModel relatedModel)
        {
            return new Admire(specificationProperty, relatedModel);
        }

        public IBiologicalChild GenerateBiologicalChild(ISpecificationProperty specificationProperty, ISpecificationModel relatedModel)
        {
            return new BiologicalChild(specificationProperty, relatedModel);
        }

        public IBiologicalParent GenerateBiologicalParent(ISpecificationProperty specificationProperty, ISpecificationModel relatedModel)
        {
            return new BiologicalParent(specificationProperty, relatedModel);
        }

        public IBiologicalParent GenerateBiologicalParent(ISpecificationModel model, ISpecificationModel relatedModel)
        {
            return new BiologicalParent(model, relatedModel);
        }

        public ICustodiedChild GenerateCustodiedChild(ISpecificationModel model, ISpecificationModel relatedModel, ISpecificationProperty externallyReferencingProperty)
        {
            return new CustodiedChild(model, externallyReferencingProperty);
        }

        public IEnemy GenerateEnemy(ISpecificationModel model, ISpecificationModel relatedModel, ISpecificationProperty externallyReferencingProperty)
        {
            return new Enemy(model, externallyReferencingProperty);
        }

        public ISpecificationEnumeration GenerateEnumeration(string name)
        {
            return new SpecificationEnumeration(name);
        }

        public IFosterChild GenerateFosterChild(ISpecificationProperty specificationProperty, ISpecificationModel relatedModel)
        {
            return new FosterChild(specificationProperty, relatedModel);
        }

        public IFosterParent GenerateFosterParent(ISpecificationProperty specificationProperty, ISpecificationModel relatedModel)
        {
            return new FosterParent(specificationProperty, relatedModel);
        }

        public IFriend GenerateFriend(ISpecificationProperty specificationProperty, ISpecificationModel relatedModel)
        {
            return new Friend(specificationProperty, relatedModel);
        }

        public IGodchild GenerateGodchild(ISpecificationProperty specificationProperty, ISpecificationModel relatedModel)
        {
            return new Godchild(specificationProperty, relatedModel);
        }

        public IGodfather GenerateGodfather(ISpecificationModel model, ISpecificationModel relatedModel, ISpecificationProperty externallyReferencingProperty)
        {
            return new Godfather(model, externallyReferencingProperty);
        }

        public IGrandchild GenerateGrandchild(ISpecificationProperty specificationProperty, ISpecificationModel relatedModel)
        {
            return new Grandchild(specificationProperty, relatedModel);
        }

        public IGrandparent GenerateGrandparent(ISpecificationProperty specificationProperty, ISpecificationModel relatedModel)
        {
            return new Grandparent(specificationProperty, relatedModel);
        }

        public IGrandparent GenerateGrandparent(ISpecificationModel model, ISpecificationModel relatedModel, ISpecificationProperty externallyReferencingProperty)
        {
            return new Grandparent(model, externallyReferencingProperty);
        }

        public IIllegitimateChild GenerateIllegitimateChild(ISpecificationProperty specificationProperty, ISpecificationModel relatedModel)
        {
            return new IllegitimateChild(specificationProperty, relatedModel);
        }

        public IIllegitimateParent GenerateIllegitimateParent(ISpecificationProperty specificationProperty, ISpecificationModel relatedModel)
        {
            return new IllegitimateParent(specificationProperty, relatedModel);
        }

        public ISpecificationKey GenerateKey(ISpecificationModel model)
        {
            return new SpecificationKey(model);
        }

        public ISpecificationModel GenerateModel(ISpecification specification, ITestingFactory testingFactory, string name)
        {
            return new SpecificationModel(specification, testingFactory, name);
        }

        public IOnlyChild GenerateOnlyChild(ISpecificationProperty specificationProperty, ISpecificationModel relatedModel)
        {
            return new OnlyChild(specificationProperty, relatedModel);
        }

        public ISpecificationProject GenerateProject()
        {
            return new SpecificationProject();
        }

        public ISpecificationProperty GenerateProperty(ISpecificationModel model, string name, string propertyType, bool required)
        {
            return new SpecificationProperty(model, name, propertyType, required);
        }

        public IRecursive GenerateRecursive(ISpecificationProperty specificationProperty)
        {
            return new Recursive(specificationProperty);
        }

        public ISibling GenerateSibling(ISpecificationModel model, ISpecificationModel relatedModel)
        {
            return new Sibling(model, relatedModel);
        }
        
        public ISingleParent GenerateSingleParent(ISpecificationProperty specificationProperty, ISpecificationModel relatedModel)
        {
            return new SingleParent(specificationProperty, relatedModel);
        }

        public IUnfitParent GenerateUnfitParent(ISpecificationProperty specificationProperty, ISpecificationModel relatedModel)
        {
            return new UnfitParent(specificationProperty, relatedModel);
        }
    }
}
