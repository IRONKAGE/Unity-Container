using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Unity.Exceptions;
using Unity.Injection;

namespace Unity.Processors
{
    public abstract partial class MemberProcessor<TMemberInfo, TData> where TMemberInfo : MemberInfo
    {
        #region Selection Processing

        protected virtual IEnumerable<Expression> ExpressionsFromSelection(Type type, IEnumerable<object> members)
        {
            foreach (var member in members)
            {

                switch (member)
                {
                    // TMemberInfo
                    case TMemberInfo info:
                        object value = DependencyAttribute.Instance; 
                        foreach (var node in AttributeFactories)
                        {
                            var attribute = info.GetCustomAttribute(node.Type);
                            if (null == attribute) continue;

                            value = null == node.Factory ? (object)attribute : node.Factory(attribute, info, null);
                            break;
                        }

                        yield return GetResolverExpression(info, value);
                        break;
                    
                        // Injection Member
                    case InjectionMember<TMemberInfo, TData> injectionMember:
                        TMemberInfo selection = MemberInfo(injectionMember, type) ??
                            throw new InvalidOperationException(NoMatchFound, new InvalidRegistrationException()); // TODO: Simplify exception throwing
                        yield return GetResolverExpression(selection, injectionMember.Data);
                        break;

                    // Unknown
                    default:
                        throw new InvalidOperationException($"Unknown MemberInfo<{typeof(TMemberInfo)}> type");
                }
            }
        }

        #endregion


        #region Implementation

        protected abstract Expression GetResolverExpression(TMemberInfo info, object resolver);

        #endregion
    }
}
