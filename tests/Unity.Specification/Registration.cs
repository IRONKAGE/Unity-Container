using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace Registration
{
    [TestClass]
    public class Native : Unity.Specification.Registration.Native.SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer();
        }
    }

    [TestClass]
    public class Extended : Unity.Specification.Registration.Extended.SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer();
        }
    }

    [TestClass]
    public class Syntax : Unity.Specification.Registration.Syntax.SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer();
        }
    }

    [TestClass]
    public class Factory : Unity.Specification.Registration.Factory.SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer();
        }
    }

    [TestClass]
    public class Instance : Unity.Specification.Registration.Instance.SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer();
        }
    }

    [TestClass]
    public class Types : Unity.Specification.Registration.Types.SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer();
        }
    }

}
