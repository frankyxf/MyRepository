using System.Configuration;

namespace Artech.BatchingHosting
{
    public class ServiceTypeElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ServiceTypeElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            var serviceTypeElement = (ServiceTypeElement)element;
            return serviceTypeElement.ServiceType.MetadataToken;
        }
    }
}