using System;
using System.Reflection;

namespace Unity.Resolution
{
    /// <summary>
    /// An implementation of <see cref="ResolverOverride"/> that
    /// acts as a decorator over another <see cref="ResolverOverride"/>.
    /// This checks to see if the current type being built is the
    /// right one before checking the inner <see cref="ResolverOverride"/>.
    /// </summary>
    [Obsolete("This type has been deprecated as degrading performance. Use ResolverOverride.OnType() instead.", false)]
    public class TypeBasedOverride : ResolverOverride,
                                     IEquatable<ParameterInfo>,
                                     IEquatable<PropertyInfo>,
                                     IEquatable<FieldInfo>
    {
        #region Constructors

        /// <summary>
        /// Create an instance of <see cref="TypeBasedOverride"/>
        /// </summary>
        /// <param name="targetType">Type to check for.</param>
        /// <param name="innerOverride">Inner override to check after type matches.</param>
        public TypeBasedOverride(Type targetType, ResolverOverride innerOverride)
            : base(targetType, null, innerOverride ?? throw new ArgumentNullException(nameof(innerOverride)))
        {
            innerOverride.OnType(targetType);
        }

        #endregion


        #region IEquatable

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Value.Equals(obj);
        }

        public bool Equals(FieldInfo other)
        {
            return Value is IEquatable<FieldInfo> info &&
                   info.Equals(other);
        }

        public bool Equals(PropertyInfo other)
        {
            return Value is IEquatable<PropertyInfo> info && 
                   info.Equals(other);
        }

        public bool Equals(ParameterInfo other)
        {
            return Value is IEquatable<ParameterInfo> info && 
                   info.Equals(other);
        }

        #endregion
    }

    /// <summary>
    /// A convenience version of <see cref="TypeBasedOverride"/> that lets you
    /// specify the type to construct via generics syntax.
    /// </summary>
    /// <typeparam name="T">Type to check for.</typeparam>
    [Obsolete("This type has been deprecated as degrading performance. Use ResolverOverride.OnType() instead.", false)]
    public class TypeBasedOverride<T> : TypeBasedOverride
    {
        /// <summary>
        /// Create an instance of <see cref="TypeBasedOverride{T}"/>.
        /// </summary>
        /// <param name="innerOverride">Inner override to check after type matches.</param>
        public TypeBasedOverride(ResolverOverride innerOverride)
            : base(typeof(T), innerOverride)
        {
        }
    }
}
