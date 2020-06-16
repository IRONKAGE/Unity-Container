using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;
using Unity.Specification.Container.Hierarchy;

namespace Container
{
    [TestClass]
    public class Hierarchy : SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer();
        }
    }

    [TestClass]
    public class IsRegistered : SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer();
        }
    }

    [TestClass]
    public class Registrations : SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer();
        }
    }
}
