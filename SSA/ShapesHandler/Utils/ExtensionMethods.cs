using System;
using System.Reflection;
using System.Text;

namespace ShapesHandler.Utils
{
    public static class ExtensionMethods
    {
        public static string ToStringExtension(this object obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(obj.GetType().Name + ": ");
            foreach (FieldInfo field in obj.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                if (Char.IsLower(field.Name[0])) // patch for this assignment purpose only.
                    continue;

                sb.Append(field.Name);
                sb.Append("=");
                sb.Append(field.GetValue(obj));
                sb.Append("; " );
            }

            return sb.ToString();
        }        
    }
}
