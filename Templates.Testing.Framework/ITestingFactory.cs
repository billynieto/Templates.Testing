using System;
using System.Collections.Generic;

namespace Templates.Testing.Framework
{
    public interface ITestingFactory
    {
        IAdoptedChild GenerateAdoptedChild(ISpecificationProperty specificationProperty, ISpecificationModel relatedModel);
        IAdoptingParent GenerateAdoptingParent(ISpecificationProperty specificationProperty, ISpecificationModel relatedModel);
        IAdmire GenerateAdmire(ISpecificationProperty specificationProperty, ISpecificationModel relatedModel);
        IBiologicalChild GenerateBiologicalChild(ISpecificationProperty specificationProperty, ISpecificationModel relatedModel);
        IBiologicalParent GenerateBiologicalParent(ISpecificationProperty specificationProperty, ISpecificationModel relatedModel);
        ICustodiedChild GenerateCustodiedChild(ISpecificationModel model, ISpecificationModel relatedModel, ISpecificationProperty externallyReferencingProperty);
        IEnemy GenerateEnemy(ISpecificationModel model, ISpecificationModel relatedModel, ISpecificationProperty externallyReferencingProperty);
        ISpecificationEnumeration GenerateEnumeration(string name);
        IFosterChild GenerateFosterChild(ISpecificationProperty specificationProperty, ISpecificationModel relatedModel);
        IFosterParent GenerateFosterParent(ISpecificationProperty specificationProperty, ISpecificationModel relatedModel);
        IFriend GenerateFriend(ISpecificationProperty specificationProperty, ISpecificationModel relatedModel);
        IGodchild GenerateGodchild(ISpecificationProperty specificationProperty, ISpecificationModel relatedModel);
        IGodfather GenerateGodfather(ISpecificationModel model, ISpecificationModel relatedModel, ISpecificationProperty externallyReferencingProperty);
        IGrandchild GenerateGrandchild(ISpecificationProperty specificationProperty, ISpecificationModel relatedModel);
        IGrandparent GenerateGrandparent(ISpecificationProperty specificationProperty, ISpecificationModel relatedModel);
        IGrandparent GenerateGrandparent(ISpecificationModel model, ISpecificationModel relatedModel, ISpecificationProperty externallyReferencingProperty);
        IIllegitimateChild GenerateIllegitimateChild(ISpecificationProperty specificationProperty, ISpecificationModel relatedModel);
        IIllegitimateParent GenerateIllegitimateParent(ISpecificationProperty specificationProperty, ISpecificationModel relatedModel);
        ISpecificationKey GenerateKey(ISpecificationModel model);
        ISpecificationModel GenerateModel(ISpecification specification, ITestingFactory testingFactory, string name);
        IOnlyChild GenerateOnlyChild(ISpecificationProperty specificationProperty, ISpecificationModel relatedModel);
        ISpecificationProject GenerateProject();
        ISpecificationProperty GenerateProperty(ISpecificationModel model, string name, string propertyType, bool required);
        IRecursive GenerateRecursive(ISpecificationProperty specificationProperty);
        ISibling GenerateSibling(ISpecificationModel model, ISpecificationModel relatedModel);
        ISingleParent GenerateSingleParent(ISpecificationProperty specificationProperty, ISpecificationModel relatedModel);
        IUnfitParent GenerateUnfitParent(ISpecificationProperty specificationProperty, ISpecificationModel relatedModel);
    }
}
