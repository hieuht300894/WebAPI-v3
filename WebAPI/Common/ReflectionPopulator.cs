using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class ReflectionPopulator
    {
        public static T CreateObject<T>()
        {
            Type type = typeof(T);

            if (type.IsValueType || type == typeof(String))
            {
                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    return (T)Convert.ChangeType(Activator.CreateInstance(type.GetGenericArguments()[0]), Nullable.GetUnderlyingType(type));
                }
                else if (type.IsValueType)
                {
                    return default(T);
                }
                else
                {
                    return (T)Convert.ChangeType(String.Empty, type);
                }
            }
            else
            {
                return Activator.CreateInstance<T>();
            }
        }
    }
}
