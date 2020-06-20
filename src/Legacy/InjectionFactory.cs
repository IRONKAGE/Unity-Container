using System;
using Unity.Builder;
using Unity.Lifetime;
using Unity.Policy;
using Unity.Resolution;

namespace Unity.Injection
{
    /// <inheritdoc />
    /// <summary>
    /// A class that lets you specify a factory method the container
    /// will use to create the object.
    /// </summary>
    /// <remarks>This factory allow using predefined <code>Func&lt;IUnityContainer, Type, string, object&gt;</code> to create types.</remarks>
    [Obsolete("InjectionFactory has been deprecated and will be removed in next release. Please use IUnityContainer.RegisterFactory(...) method instead.", false)]
    public class InjectionFactory : InjectionMember, IAddPolicies
    {
        #region Fields

        private readonly Func<IUnityContainer, Type, string, object> _factoryFunc;

        #endregion


        #region Constructors

        /// <summary>
        /// Create a new instance of <see cref="InjectionFactory"/> with
        /// the given factory function.
        /// </summary>
        /// <param name="factoryFunc">Factory function.</param>
        public InjectionFactory(Func<IUnityContainer, object> factoryFunc)
        {
            if (null == factoryFunc) throw new ArgumentNullException(nameof(factoryFunc));
            _factoryFunc = (c, t, s) => factoryFunc(c);
        }

        /// <summary>
        /// Create a new instance of <see cref="InjectionFactory"/> with
        /// the given factory function.
        /// </summary>
        /// <param name="factoryFunc">Factory function.</param>
        public InjectionFactory(Func<IUnityContainer, Type, string, object> factoryFunc)
        {
            _factoryFunc = factoryFunc ?? throw new ArgumentNullException(nameof(factoryFunc));
        }

        public override bool BuildRequired => false;

        #endregion


        #region InjectionMember

        public void AddPolicies<TPolicySet>(Type type, string? name, ref TPolicySet policies) where TPolicySet : IPolicySet
        {
            // Check if Per Resolve lifetime is required
            var lifetime = policies.Get(typeof(LifetimeManager));
            if (lifetime is PerResolveLifetimeManager)
            {
                policies.Set(typeof(ResolveDelegate<BuilderContext>), CreatePerResolveLegacyPolicy());
            }
            else
            {
                policies.Set(typeof(ResolveDelegate<BuilderContext>), CreateLegacyPolicy());
            }

            // Factory methods

            ResolveDelegate<BuilderContext> CreateLegacyPolicy()
            {
                return (ref BuilderContext c) => _factoryFunc(c.Container, c.Type, c.Name);
            }

            ResolveDelegate<BuilderContext> CreatePerResolveLegacyPolicy()
            {
                return (ref BuilderContext context) =>
                {
                    var result = _factoryFunc(context.Container, context.Type, context.Name);
                    var perBuildLifetime = new InternalPerResolveLifetimeManager(result);

                    context.Set(context.Type, context.Name, typeof(LifetimeManager), perBuildLifetime);
                    return result;
                };
            }
        }

        #endregion


        #region Nested Types

        internal sealed class InternalPerResolveLifetimeManager : PerResolveLifetimeManager
        {
            public InternalPerResolveLifetimeManager(object obj)
            {
                value = obj;
                InUse = true;
            }
        }

        #endregion
    }
}
