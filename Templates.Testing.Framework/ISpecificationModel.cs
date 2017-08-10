using System;
using System.Collections.Generic;

using Templates.Framework;

namespace Templates.Testing.Framework
{
    public interface ISpecificationModel
    {
        IList<IAdmire> Admires { get; }
        IList<IAdoptedChild> AdoptedChildren { get; }
        IList<IAdoptingParent> AdoptingParents { get; }
        IList<ISpecificationModel> AffectedModels { get; }
        IList<IAssociated> Associates { get; }
        IList<IBiologicalChild> BiologicalChildren { get; }
        IList<IBiologicalParent> BiologicalParents { get; }
        bool CanDelete { get; set; }
        bool CanInsert { get; set; }
        bool CanUpdate { get; set; }
        IList<IChild> Children { get; }
        IList<IRelationship> CloseRelationships { get; }
        IList<ICustodiedChild> CustodiedChildren { get; }
        IList<ISpecificationModel> Dependants { get; }
        IList<IRelationship> DirectlyAffectedRelationships { get; }
        IList<IRelationship> DirectlyDepandantRelationships { get; }
        IList<IDivorce> Divorces { get; }
        IList<IEnemy> Enemies { get; }
        IList<IFosterChild> FosterChildren { get; }
        IList<IFosterParent> FosterParents { get; }
        IList<IFriend> Friends { get; }
        IList<IGodchild> Godchildren { get; }
        IList<IGodfather> Godfathers { get; }
        IList<ISpecificationModel> Guardians { get; }
        bool HasRepositoryAndService { get; set; }
        IList<IIllegitimateChild> IllegitimateChildren { get; }
        IList<IIllegitimateParent> IllegitimateParents { get; }
        IVariable Interface { get; set; }
        ISpecificationKey Key { get; set; }
        IVariable KeyInterface { get; set; }
        IVariable KeyVariable { get; set; }
        IList<IMarriage> Marriages { get; }
        IList<IRelationship> MonitoredRelationships { get; }
        IList<IOnlyChild> OnlyChildren { get; }
        IList<IRelationship> OwnedRelationships { get; }
        IList<IVariable> Parameter { get; }
        IList<IParent> Parents { get; }
        bool ReadOnly { get; set; }
        IList<IRecursive> Recursive { get; }
        IList<IRelationship> Relationships { get; }
        IList<IRelationship> RelationshipsRequiredForIntegrationTesting { get; }
        IList<IRelationship> RelationshipsRequiredForUnitTesting { get; }
        IList<IRelationship> RelationshipsToDelete { get; }
        IList<IRelationship> RelationshipsToFind { get; }
        IList<IRelationship> RelationshipsToManage { get; }
        IList<IRelationship> RelationshipsToNotDelete { get; }
        IList<IRelationship> RelationshipsToNotFind { get; }
        IList<IRelationship> RelationshipsToNotFindOnFindSingle { get; }
        IList<IRelationship> RelationshipsToNotManage { get; }
        IList<IVariable> RepositoryParameter { get; set; }
        IVariable RepositoryInterface { get; set; }
        IVariable RepositoryVariable { get; set; }
        IVariable SearchMultipleInterface { get; set; }
        IVariable SearchMultipleVariable { get; set; }
        IVariable SearchInterface { get; set; }
        IVariable SearchVariable { get; set; }
        IList<ISeperated> Seperations { get; }
        IVariable ServiceInterface { get; set; }
        IVariable ServiceVariable { get; set; }
        IList<ISibling> Siblings { get; } 
        IList<ISignificantOther> SignificantOthers { get; }
        IList<ISingleParent> SingleParents { get; }
        Dictionary<string, ISpecificationProperty> SpecificationProperties { get; set; }
        Tier Tier { get; set; }
        IList<IUnfitParent> UnfitParents { get; }
        IVariable Variable { get; set; }
        
        void SetupReciprocatedRelationship(ISpecificationModel relatedModel, IRelationship reciprocatedRelationship);
        void SetupRelationship(ISpecificationModel relatedModel);
        void SetupSiblingRelationship(ISpecificationModel relatedModel);
        IList<ISpecificationModel> FindAffectedModels(IList<ISpecificationModel> modelsAlreadyChecked);
        IList<ISpecificationModel> FindDependants(IList<ISpecificationModel> modelsAlreadyChecked);
        IList<ISpecificationModel> FindGuardians(IList<ISpecificationModel> modelsAlreadyChecked);
    }
}
