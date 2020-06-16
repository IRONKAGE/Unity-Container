using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace Compiled.Resolution
{
    [TestClass]
    public class Array : Unity.Specification.Diagnostic.Resolution.Array.SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer().AddNewExtension<Diagnostic>().AddExtension(new ForceCompillation());
        }
    }

    [TestClass]
    public class Basics : Unity.Specification.Diagnostic.Resolution.Basics.SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer().AddNewExtension<Diagnostic>().AddExtension(new ForceCompillation());
        }
    }

    [TestClass]
    public class Deferred : Unity.Specification.Diagnostic.Resolution.Deferred.SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer().AddNewExtension<Diagnostic>().AddExtension(new ForceCompillation());
        }
    }

    [TestClass]
    public class Enumerable : Unity.Specification.Diagnostic.Resolution.Enumerable.SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer().AddNewExtension<Diagnostic>().AddExtension(new ForceCompillation());
        }
    }

    [TestClass]
    public class Generic : Unity.Specification.Diagnostic.Resolution.Generic.SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer().AddNewExtension<Diagnostic>().AddExtension(new ForceCompillation());
        }
    }

    [TestClass]
    public class Lazy : Unity.Specification.Diagnostic.Resolution.Lazy.SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer().AddNewExtension<Diagnostic>().AddExtension(new ForceCompillation());
        }
    }

    [TestClass]
    public class Mapping : Unity.Specification.Diagnostic.Resolution.Mapping.SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer().AddNewExtension<Diagnostic>().AddExtension(new ForceCompillation());
        }
    }

    [TestClass]
    public class Overrides : Unity.Specification.Diagnostic.Property.Overrides.SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer().AddNewExtension<Diagnostic>().AddExtension(new ForceCompillation());
        }
    }
}


namespace Resolved.Resolution
{
    [TestClass]
    public class Array : Unity.Specification.Diagnostic.Resolution.Array.SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer().AddNewExtension<Diagnostic>().AddExtension(new ForceActivation());
        }
    }

    [TestClass]
    public class Basics : Unity.Specification.Diagnostic.Resolution.Basics.SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer().AddNewExtension<Diagnostic>().AddExtension(new ForceActivation());
        }
    }

    [TestClass]
    public class Deferred : Unity.Specification.Diagnostic.Resolution.Deferred.SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer().AddNewExtension<Diagnostic>().AddExtension(new ForceActivation());
        }
    }

    [TestClass]
    public class Enumerable : Unity.Specification.Diagnostic.Resolution.Enumerable.SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer().AddNewExtension<Diagnostic>().AddExtension(new ForceActivation());
        }
    }

    [TestClass]
    public class Generic : Unity.Specification.Diagnostic.Resolution.Generic.SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer().AddNewExtension<Diagnostic>().AddExtension(new ForceActivation());
        }
    }

    [TestClass]
    public class Lazy : Unity.Specification.Diagnostic.Resolution.Lazy.SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer().AddNewExtension<Diagnostic>().AddExtension(new ForceActivation());
        }
    }

    [TestClass]
    public class Mapping : Unity.Specification.Diagnostic.Resolution.Mapping.SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer().AddNewExtension<Diagnostic>().AddExtension(new ForceActivation());
        }
    }

    [TestClass]
    public class Overrides : Unity.Specification.Diagnostic.Property.Overrides.SpecificationTests
    {
        [TestInitialize] public override void Setup() => base.Setup();

        public override IUnityContainer GetContainer()
        {
            return new UnityContainer().AddNewExtension<Diagnostic>().AddExtension(new ForceActivation());
        }
    }
}
