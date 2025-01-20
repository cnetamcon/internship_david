using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Extensions
{
    public static class ObjectExtensions
    {
        public static void IsNull(this object obj, string message)
        {
            if (obj == null)
            {
                throw new NullReferenceException(message);
            }
        }
        public static void Copy<Tin, TFrom>(this Tin obj, TFrom fromObj)
        {
            if (obj == null || fromObj == null) return;

            Func<PropertyInfo, bool> query = p => p.PropertyType.IsValueType || p.PropertyType.Name == "String";

            var fields1 = obj.GetType().GetProperties().Where(query).ToArray();
            var fields2 = fromObj.GetType().GetProperties().Where(query).ToArray();

            for (int i = 0; i < fields2.Length; i++)
            {
                if (fields2[i].Name == "Created")
                {
                    continue;
                }

                var value = fields2[i].GetValue(fromObj);
                fields1.FirstOrDefault(x => x.Name == fields2[i].Name)?.SetValue(obj, value);
            }
        }


        public static bool CompareProperty(this object n, object x, string propertyName)
        {
            return n.GetType().GetProperty(propertyName).GetValue(n) == x.GetType().GetProperty(propertyName).GetValue(x);
        }


        public static string PrintFields(this object obj)
        {
            if (obj == null) return "Object is null";

            var type = obj.GetType();
            var fields = type.GetFields();
            StringBuilder sb = new StringBuilder("\r\n");

            var maxLength = fields.Max(x => x.Name.Length);

            foreach (var f in fields)
            {
                sb.Append($"{f.Name.PadRight(maxLength, ' ')} :\t{f.GetValue(obj)}\r\n");
            }
            return sb.ToString();
        }
    }
}
