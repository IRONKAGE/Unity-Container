using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;
using Unity.Specification.Factory.Registration;

namespace Factory
{
    [TestClass]
    public class Registration : SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer();
        }
    }

    [TestClass]
    public class Resolution : SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer();
        }
    }
}
