using System;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;

namespace Fred.WcfServiceBatchHosting
{
    public class AssemblyQualifiedTypeNameConverter : ConfigurationConverterBase
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var typeName = (string)value;
            if (string.IsNullOrEmpty(typeName))
            {
                return null;
            }
            var result = Type.GetType(typeName, false);
            if (result == null)
            {
                throw new ArgumentException(string.Format("不能加载类型\"{0}\"", typeName));
            }
            return result;
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            var type = value as Type;
            if (null == type)
            {
                throw new ArgumentNullException("value");
            }
            return type.AssemblyQualifiedName;
        }
    }
}
