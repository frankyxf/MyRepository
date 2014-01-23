using System;
using System.ComponentModel;
using System.Configuration;

namespace Fred.WcfServiceBatchHosting
{
    public class ServiceTypeElement : ConfigurationElement
    {
        [ConfigurationProperty("type", IsRequired = true)]
        [TypeConverter(typeof(AssemblyQualifiedTypeNameConverter))]
        public Type ServiceType
        {
            get { return (Type)this["type"]; }
        }
    }
}