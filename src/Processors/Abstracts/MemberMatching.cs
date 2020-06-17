using System;
using System.Reflection;

namespace Unity.Injection
{
    public static class MemberMatching
    {
        public static bool MatchMemberInfo(this object[] data, MethodBase info)
        {
            var parameters = info.GetParameters();

            if ((data?.Length ?? 0) != parameters.Length) return false;

            for (var i = 0; i < (data?.Length ?? 0); i++)
            {
                if (Matches(data![i], parameters[i].ParameterType))
                    continue;

                return false;
            }

            return true;
        }

        public static bool Matches(this object data, Type match)
        {
            return data switch
            {
                null => (null == match) || !match.IsValueType() || (null != Nullable.GetUnderlyingType(match)),
                Type _ when typeof(Type).Equals(match) => true,
                Type type                              => MatchesType(type, match),
                IMatch<Type> equatable                 => equatable.Match(match),
                _                                      => MatchesObject(data, match),
            };
        }

        public static bool MatchesType(this Type type, Type match)
        {
            if (null == type) return true;

            if (match.IsAssignableFrom(type)) 
                return true;

            if (typeof(Array) == type && match.IsArray)
                return true;

            if (type.IsGenericType() && type.IsGenericTypeDefinition() && match.IsGenericType() &&
                type.GetGenericTypeDefinition() == match.GetGenericTypeDefinition())
                return true;

            return false;
        }

        public static bool MatchesObject(this object data, Type match)
        {
            var type = data is Type ? typeof(Type) : data?.GetType();

            if (null == type) return true;

            return match.IsAssignableFrom(type);
        }
    }
}
