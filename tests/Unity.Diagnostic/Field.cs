using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace Compiled.Field
{
    [TestClass]
    public class Validation : Unity.Specification.Diagnostic.Field.Validation.SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer().AddExtension(new ForceCompillation())
                                       .AddExtension(new Diagnostic());
        }
    }

    [TestClass]
    public class Attribute : Unity.Specification.Diagnostic.Field.Attribute.SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer().AddExtension(new ForceCompillation())
                                       .AddExtension(new ForceCompillation());
        }
    }

    [TestClass]
    public class Injection : Unity.Specification.Diagnostic.Field.Injection.SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer().AddExtension(new Diagnostic())
                                       .AddExtension(new ForceCompillation());
        }
    }

    [TestClass]
    public class Override : Unity.Specification.Diagnostic.Field.Overrides.SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer().AddExtension(new ForceCompillation()).AddExtension(new ForceCompillation());
        }
    }
}


namespace Resolved.Field
{
    [TestClass]
    public class Validation : Unity.Specification.Diagnostic.Field.Validation.SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();
        public override IUnityContainer GetContainer()
        {
            return new UnityContainer().AddExtension(new ForceActivation())
                                       .AddExtension(new Diagnostic());
        }
    }

    [TestClass]
    public class Attribute : Unity.Specification.Diagnostic.Field.Attribute.SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer().AddExtension(new ForceCompillation())
                                       .AddExtension(new ForceActivation());
        }
    }

    [TestClass]
    public class Injection : Unity.Specification.Diagnostic.Field.Injection.SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer().AddExtension(new Diagnostic())
                                       .AddExtension(new ForceActivation());
        }
    }

    [TestClass]
    public class Override : Unity.Specification.Diagnostic.Field.Overrides.SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer().AddExtension(new ForceCompillation()).AddExtension(new ForceActivation());
        }
    }
}
