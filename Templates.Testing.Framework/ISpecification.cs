using System;
using System.Collections.Generic;

using Templates.Framework;

namespace Templates.Testing.Framework
{
    public interface ISpecification
    {
        IVariableType ConnectionStateType { get; }
        IVariable ConnectionStateVariable { get; }
        IVariable DataSetVariable { get; }
        IInterface KeyInterface { get; }
        IClass ModelClass { get; }
        IClass ModelFactoryClass { get; }
        IInterface ModelInterface { get; }
        IInterface ModelFactoryInterface { get; }
        IList<IVariable> ModelFactoryParameter { get; }
        IVariable ModelFactoryVariable { get; }
        IInterface MultipleSearchInterface { get; }
        IInterface RepositoryInterface { get; }
        IInterface ServiceInterface { get; }
        IInterface SingleSearchInterface { get; }
        IVariable TestContextVariable { get; }
        IVariable TransactionVariable { get; }

        IList<string> Comments { get; set; }
        Dictionary<string, ISpecificationEnumeration> Enumerations { get; set; }
        IList<string> Errors { get; set; }
        Dictionary<string, ISpecificationModel> Models { get; set; }
        ISpecificationSettings Settings { get; set; }
        IList<string> Warnings { get; set; }
    }
}
