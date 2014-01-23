using System;
using System.ComponentModel;
using System.Configuration;

namespace Artech.BatchingHosting
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