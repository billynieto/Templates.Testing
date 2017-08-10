using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

using Templates.Framework;
using Templates.Testing.Framework;

namespace Templates.Testing
{
    public class SpecificationSettings : ISpecificationSettings
    {
        protected INamespace frameworkNamespace;
        protected INamespace frameworkModelsNamespace;
        protected INamespace frameworkRepositoriesNamespace;
        protected INamespace frameworkServicesNamespace;
        protected INamespace integrationTestCoreServicesNamespace;
        protected INamespace testFactoriesNamespace;
        protected INamespace integrationTestServicesNamespace;
        protected INamespace modelsNamespace;
        protected INamespace repositoriesNamespace;
        protected INamespace servicesNamespace;
        protected ISpecificationSolution solution;
        protected INamespace unitTestCoreModelsNamespace;
        protected INamespace unitTestCoreRepositoriesNamespace;
        protected INamespace unitTestCoreServicesNamespace;
        protected INamespace unitTestModelsNamespace;
        protected INamespace unitTestRepositoriesNamespace;
        protected INamespace unitTestServicesNamespace;

        public INamespace FrameworkNamespace { get { if (this.frameworkNamespace == null) this.frameworkNamespace = Solution.FrameworkProject.Namespace; return this.frameworkNamespace; } }
        public INamespace FrameworkModelsNamespace { get { if (this.frameworkModelsNamespace == null) this.frameworkModelsNamespace = new TemplateNamespace(Solution.FrameworkProject.Namespace, "Models"); return this.frameworkModelsNamespace; } }
        public INamespace FrameworkRepositoriesNamespace { get { if (this.frameworkRepositoriesNamespace == null) this.frameworkRepositoriesNamespace = new TemplateNamespace(Solution.FrameworkProject.Namespace, "Repositories"); return this.frameworkRepositoriesNamespace; } }
        public INamespace FrameworkServicesNamespace { get { if (this.frameworkServicesNamespace == null) this.frameworkServicesNamespace = new TemplateNamespace(Solution.FrameworkProject.Namespace, "Services"); return this.frameworkServicesNamespace; } }
        public INamespace IntegrationTestCoreServicesNamespace { get { if (this.integrationTestCoreServicesNamespace == null) this.integrationTestCoreServicesNamespace = new TemplateNamespace(Solution.IntegrationTestProject.Namespace, "Core.Services"); return this.integrationTestCoreServicesNamespace; } }
        public INamespace IntegrationTestServicesNamespace { get { if (this.integrationTestServicesNamespace == null) this.integrationTestServicesNamespace = new TemplateNamespace(Solution.IntegrationTestProject.Namespace, "Services"); return this.integrationTestServicesNamespace; } }
        public INamespace ModelsNamespace { get { if (this.modelsNamespace == null) this.modelsNamespace = new TemplateNamespace(Solution.ModelProject.Namespace, "Models"); return this.modelsNamespace; } }
        public INamespace RepositoriesNamespace { get { if (this.repositoriesNamespace == null) this.repositoriesNamespace = new TemplateNamespace(Solution.RepositoryProject.Namespace, "Repositories"); return this.repositoriesNamespace; } }
        public INamespace ServicesNamespace { get { if (this.servicesNamespace == null) this.servicesNamespace = new TemplateNamespace(Solution.ServiceProject.Namespace, "Services"); return this.servicesNamespace; } }
        public ISpecificationSolution Solution { get { return this.solution; } set { this.solution = value; } }
        public INamespace TestFactoriesNamespace { get { if (this.testFactoriesNamespace == null) this.testFactoriesNamespace = new TemplateNamespace(Solution.TestProject.Namespace, "Factories"); return this.testFactoriesNamespace; } }
        public INamespace UnitTestCoreModelsNamespace { get { if (this.unitTestCoreModelsNamespace == null) this.unitTestCoreModelsNamespace = new TemplateNamespace(Solution.UnitTestProject.Namespace, "Core.Models"); return this.unitTestCoreModelsNamespace; } }
        public INamespace UnitTestCoreRepositoriesNamespace { get { if (this.unitTestCoreRepositoriesNamespace == null) this.unitTestCoreRepositoriesNamespace = new TemplateNamespace(Solution.UnitTestProject.Namespace, "Core.Repositories"); return this.unitTestCoreRepositoriesNamespace; } }
        public INamespace UnitTestCoreServicesNamespace { get { if (this.unitTestCoreServicesNamespace == null) this.unitTestCoreServicesNamespace = new TemplateNamespace(Solution.UnitTestProject.Namespace, "Core.Services"); return this.unitTestCoreServicesNamespace; } }
        public INamespace UnitTestModelsNamespace { get { if (this.unitTestModelsNamespace == null) this.unitTestModelsNamespace = new TemplateNamespace(Solution.UnitTestProject.Namespace, "Models"); return this.unitTestModelsNamespace; } }
        public INamespace UnitTestRepositoriesNamespace { get { if (this.unitTestRepositoriesNamespace == null) this.unitTestRepositoriesNamespace = new TemplateNamespace(Solution.UnitTestProject.Namespace, "Repositories"); return this.unitTestRepositoriesNamespace; } }
        public INamespace UnitTestServicesNamespace { get { if (this.unitTestServicesNamespace == null) this.unitTestServicesNamespace = new TemplateNamespace(Solution.UnitTestProject.Namespace, "Services"); return this.unitTestServicesNamespace; } }

        public SpecificationSettings(string solutionName)
        {
            this.solution = new SpecificationSolution(solutionName);
        }
    }

    public class SpecificationSolution : ISpecificationSolution
    {
        protected string name;
        protected INamespace _namespace;
        protected ISpecificationProject frameworkProject;
        protected ISpecificationProject integrationTestProject;
        protected ISpecificationProject modelProject;
        protected ISpecificationProject repositoryProject;
        protected ISpecificationProject serviceProject;
        protected ISpecificationProject testProject;
        protected ISpecificationProject unitTestProject;

        public string Name { get { return this.name; } }
        public INamespace Namespace { get { if (this._namespace == null) this._namespace = new TemplateNamespace(Name); return this._namespace; } }
        public ISpecificationProject FrameworkProject { get { return this.frameworkProject; } set { this.frameworkProject = value; this.frameworkProject.Solution = this; } }
        public ISpecificationProject IntegrationTestProject { get { return this.integrationTestProject; } set { this.integrationTestProject = value; this.integrationTestProject.Solution = this; } }
        public ISpecificationProject ModelProject { get { return this.modelProject; } set { this.modelProject = value; this.modelProject.Solution = this; } }
        public ISpecificationProject RepositoryProject { get { return this.repositoryProject; } set { this.repositoryProject = value; this.repositoryProject.Solution = this; } }
        public ISpecificationProject ServiceProject { get { return this.serviceProject; } set { this.serviceProject = value; this.serviceProject.Solution = this; } }
        public ISpecificationProject TestProject { get { return this.testProject; } set { this.testProject = value; this.testProject.Solution = this; } }
        public ISpecificationProject UnitTestProject { get { return this.unitTestProject; } set { this.unitTestProject = value; this.unitTestProject.Solution = this; } }

        public SpecificationSolution(string name)
        {
            this.name = name;
            this.frameworkProject = new SpecificationProject() { Name = "Framework", Solution = this };
            this.integrationTestProject = new SpecificationProject() { Name = "Test.Integration", Solution = this };
            this.modelProject = new SpecificationProject() { Name = Namespace.Name, Solution = this };
            this.repositoryProject = new SpecificationProject() { Name = "Server", Solution = this };
            this.serviceProject = new SpecificationProject() { Name = Namespace.Name, Solution = this };
            this.testProject = new SpecificationProject() { Name = "Test", Solution = this };
            this.unitTestProject = new SpecificationProject() { Name = "Test.Unit", Solution = this };
        }
    }

    public class SpecificationProject : ISpecificationProject
    {
        protected INamespace _namespace;

        public string Name { get; set; }
        public ISpecificationSolution Solution { get; set; }

        public INamespace Namespace
        {
            get
            {
                if (this._namespace == null)
                {
                    if (Name == Solution.Name)
                        this._namespace = Solution.Namespace;
                    else
                        this._namespace = new TemplateNamespace(Solution.Namespace, Name);
                }

                return this._namespace;
            }
        }
    }
}
