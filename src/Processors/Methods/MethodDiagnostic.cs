using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Unity.Builder;
using Unity.Injection;
using Unity.Policy;
using Unity.Registration;
using Unity.Resolution;

namespace Unity.Processors
{
    public class MethodDiagnostic : MethodProcessor
    {
        #region Constructors

        public MethodDiagnostic(IPolicySet policySet, UnityContainer container)
            : base(policySet, container)
        {
        }

        #endregion


        #region Overrides

        public override IEnumerable<object> Select(Type type, IPolicySet registration)
        {
            HashSet<object> memberSet = new HashSet<object>();

            // Select Injected Members
            if (null != ((InternalRegistration)registration).InjectionMembers)
            {
                foreach (var injectionMember in ((InternalRegistration)registration).InjectionMembers)
                {
                    if (injectionMember is InjectionMember<MethodInfo, object[]> && memberSet.Add(injectionMember))
                        yield return injectionMember;
                }
            }

            // Select Attributed members
            foreach (var member in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic |
                                                   BindingFlags.Instance | BindingFlags.Static))
            {
                for (var i = 0; i < AttributeFactories.Length; i++)
                {
                    if (!member.IsDefined(AttributeFactories[i].Type) ||
                        !memberSet.Add(member)) continue;

                    // Validate
                    if (member.IsStatic)
                    {
                        throw new ArgumentException(
                            $"Static method {member.Name} on type '{member.DeclaringType.Name}' is marked for injection. Static methods cannot be injected");
                    }

                    if (member.IsPrivate)
                        throw new InvalidOperationException(
                            $"Private method '{member.Name}' on type '{member.DeclaringType.Name}' is marked for injection. Private methods cannot be injected");

                    if (member.IsFamily)
                        throw new InvalidOperationException(
                            $"Protected method '{member.Name}' on type '{member.DeclaringType.Name}' is marked for injection. Protected methods cannot be injected");

                    if (member.IsGenericMethodDefinition)
                    {
                        throw new ArgumentException(
                            $"Open generic method {member.Name} on type '{member.DeclaringType.Name}' is marked for injection. Open generic methods cannot be injected.");
                    }

                    var parameters = member.GetParameters();
                    if (parameters.Any(param => param.IsOut))
                    {
                        throw new ArgumentException(
                            $"Method {member.Name} on type '{member.DeclaringType.Name}' is marked for injection. Methods with 'out' parameters cannot be injected.");
                    }

                    if (parameters.Any(param => param.ParameterType.IsByRef))
                    {
                        throw new ArgumentException(
                            $"Method {member.Name} on type '{member.DeclaringType.Name}' is marked for injection. Methods with 'ref' parameters cannot be injected.");
                    }

                    yield return member;
                    break;
                }
            }
        }

        protected override Expression GetResolverExpression(MethodInfo info, object resolvers)
        {
            var ex = Expression.Variable(typeof(Exception));
            var exData = Expression.MakeMemberAccess(ex, DataProperty);
            var block = Expression.Block(typeof(void),
                Expression.Call(exData, AddMethod,
                        Expression.Convert(NewGuid, typeof(object)),
                        Expression.Constant(info, typeof(object))),
                Expression.Rethrow(typeof(void)));

            return
                Expression.TryCatch(
                    Expression.Call(
                        Expression.Convert(BuilderContextExpression.Existing, info.DeclaringType),
                        info, CreateDiagnosticParameterExpressions(info.GetParameters(), resolvers)),
                Expression.Catch(ex, block));
        }

        protected override ResolveDelegate<BuilderContext> GetResolverDelegate(MethodInfo info, object resolvers)
        {
            var parameterResolvers = CreateDiagnosticParameterResolvers(info.GetParameters(), resolvers).ToArray();
            return (ref BuilderContext c) =>
            {
                try
                {
                    if (null == c.Existing) return c.Existing;

                    var parameters = new object[parameterResolvers.Length];
                    for (var i = 0; i < parameters.Length; i++)
                        parameters[i] = parameterResolvers[i](ref c);

                    info.Invoke(c.Existing, parameters);
                }
                catch (Exception ex)
                {
                    ex.Data.Add(Guid.NewGuid(), info);
                    throw;
                }

                return c.Existing;
            };
        }

        #endregion


        #region Validation

        //protected override MethodInfo? GetInjectedInfo(InjectionMember<MethodInfo, object[]> member, Type type)
        //{
        //    // Select valid constructor
        //    MethodInfo? selection = null;
        //    foreach (var method in DeclaredMembers(type))
        //    {
        //        if (member is IComparable<MethodInfo> comparer && 0 > comparer.CompareTo(method)) continue;

        //        if (null != selection)
        //        {
        //            var message = $" InjectionMethod({member})  is ambiguous \n" +
        //                $" It could be matched with more than one method on type '{type.Name}': \n\n" +
        //                $"    {selection} \n    {method}";

        //            throw new InvalidOperationException(message);
        //        }

        //        selection = method;
        //    }

        //    // stop if found
        //    if (null != selection) return selection;

        //    // Select invalid constructor
        //    foreach (var info in type.GetMethods(BindingFlags.NonPublic | BindingFlags.Public |
        //                                         BindingFlags.Instance  | BindingFlags.Static)
        //                             .Where(method => method.Name == member.Name &&  
        //                                             (method.IsFamily || method.IsPrivate || method.IsStatic)))
        //    {
        //        if (member is IComparable<MethodInfo> comparer && 0 > comparer.CompareTo(info)) continue;

        //        if (info.IsStatic)
        //        {
        //            var message = $" InjectionMethod({member})  does not match any valid methods \n" +
        //                $" It matches static method {info} but static methods are not supported.";

        //            throw new InvalidOperationException(message);
        //        }

        //        if (info.IsPrivate)
        //        {
        //            var message = $" InjectionMethod({member})  does not match any valid constructors \n" +
        //                $" It matches private method {info} but private methods are not supported.";

        //            throw new InvalidOperationException(message);
        //        }

        //        if (info.IsFamily)
        //        {
        //            var message = $" InjectionMethod({member})  does not match any valid constructors \n" +
        //                $" It matches protected method {info} but protected methods are not supported.";

        //            throw new InvalidOperationException(message);
        //        }
        //    }

        //    throw new InvalidOperationException(
        //        $"InjectionMethod({member}) could not be matched with any method on type {type.Name}.");
        //}

        #endregion
    }
}
