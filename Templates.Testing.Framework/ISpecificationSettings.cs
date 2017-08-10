using System;
using System.Collections.Generic;

using Templates.Framework;

namespace Templates.Testing.Framework
{
    public interface ISpecificationSettings
    {
        INamespace FrameworkNamespace { get; }
        INamespace FrameworkModelsNamespace { get; }
        INamespace FrameworkRepositoriesNamespace { get; }
        INamespace FrameworkServicesNamespace { get; }
        INamespace IntegrationTestCoreServicesNamespace { get; }
        INamespace IntegrationTestServicesNamespace { get; }
        INamespace ModelsNamespace { get; }
        INamespace RepositoriesNamespace { get; }
        INamespace ServicesNamespace { get; }
        ISpecificationSolution Solution { get; set; }
        INamespace TestFactoriesNamespace { get; }
        INamespace UnitTestCoreModelsNamespace { get; }
        INamespace UnitTestCoreRepositoriesNamespace { get; }
        INamespace UnitTestCoreServicesNamespace { get; }
        INamespace UnitTestModelsNamespace { get; }
        INamespace UnitTestRepositoriesNamespace { get; }
        INamespace UnitTestServicesNamespace { get; }
    }

    public interface ISpecificationSolution
    {
        string Name { get; }
        INamespace Namespace { get; }
        ISpecificationProject FrameworkProject { get; set; }
        ISpecificationProject IntegrationTestProject { get; set; }
        ISpecificationProject ModelProject { get; set; }
        ISpecificationProject RepositoryProject { get; set; }
        ISpecificationProject ServiceProject { get; set; }
        ISpecificationProject TestProject { get; set; }
        ISpecificationProject UnitTestProject { get; set; }
    }

    public interface ISpecificationProject
    {
        string Name { get; set; }
        INamespace Namespace { get; }
        ISpecificationSolution Solution { get; set; }
    }
}
