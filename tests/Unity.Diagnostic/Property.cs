using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace Compiled.Property
{
    [TestClass]
    public class Validation : Unity.Specification.Diagnostic.Property.Validation.SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer().AddExtension(new ForceCompillation())
                                       .AddExtension(new Diagnostic());
        }
    }

    [TestClass]
    public class Attribute : Unity.Specification.Diagnostic.Property.Attribute.SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer().AddExtension(new ForceCompillation())
                                       .AddExtension(new ForceCompillation());
        }
    }

    [TestClass]
    public class Injection : Unity.Specification.Diagnostic.Property.Injection.SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer().AddExtension(new Diagnostic())
                                       .AddExtension(new ForceCompillation());
        }
    }

    [TestClass]
    public class Override : Unity.Specification.Diagnostic.Property.Overrides.SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer().AddExtension(new ForceCompillation()).AddExtension(new ForceCompillation());
        }
    }
}


namespace Resolved.Property
{
    [TestClass]
    public class Validation : Unity.Specification.Diagnostic.Property.Validation.SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();
        public override IUnityContainer GetContainer()
        {
            return new UnityContainer().AddExtension(new ForceActivation())
                                       .AddExtension(new Diagnostic());
        }
    }

    [TestClass]
    public class Attribute : Unity.Specification.Diagnostic.Property.Attribute.SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer().AddExtension(new ForceCompillation())
                                       .AddExtension(new ForceActivation());
        }
    }

    [TestClass]
    public class Injection : Unity.Specification.Diagnostic.Property.Injection.SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer().AddExtension(new Diagnostic())
                                       .AddExtension(new ForceActivation());
        }
    }

    [TestClass]
    public class Override : Unity.Specification.Diagnostic.Property.Overrides.SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer().AddExtension(new ForceCompillation()).AddExtension(new ForceActivation());
        }
    }
}
