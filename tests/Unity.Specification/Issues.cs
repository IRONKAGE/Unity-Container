using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace Issues
{
    [TestClass]
    public class GitHub : Unity.Specification.Issues.GitHub.SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer();
        }
    }

    [TestClass]
    public class CodePlex : Unity.Specification.Issues.Codeplex.SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer();
        }
    }
}
