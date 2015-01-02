using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.Serialization;

namespace FreeAgent.Helpers
{
    public static class EnumHelpers
    {
        public static string GetMemberValue(this Enum enumValue)
        {
            var attribute = enumValue.GetAttributeOfType<EnumMemberAttribute>();

            return attribute != null ? attribute.Value : enumValue.ToString();
        }
        
        public static T GetAttributeOfType<T>(this Enum enumVal) where T : Attribute
        {
            var result = enumVal
                            .GetType()
                            .GetTypeInfo()
                            .GetDeclaredField(enumVal.ToString())
                            .GetCustomAttribute<T>(false);

            return result;
        }
    }
}
