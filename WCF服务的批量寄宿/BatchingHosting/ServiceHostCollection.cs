using System;
using System.ServiceModel;
using System.Collections.ObjectModel;

namespace Artech.BatchingHosting
{
    public class ServiceHostCollection : Collection<ServiceHost>, IDisposable
    {
        public ServiceHostCollection(params Type[] serviceTypes)
        {
            var settings = BatchingHostingSettings.GetSection();
            foreach (ServiceTypeElement element in settings.ServiceTypes)
            {
                Add(element.ServiceType);
            }

            if (null != serviceTypes)
            {
                Array.ForEach(serviceTypes, serviceType => Add(new ServiceHost(serviceType)));
            }
        }

        public void Open()
        {
            foreach (var host in this)
            {
                host.Open();
            }
        }

        public void Dispose()
        {
            foreach (IDisposable host in this)
            {
                host.Dispose();
            }
        }

        private void Add(params Type[] serviceTypes)
        {
            if (null != serviceTypes)
            {
                Array.ForEach(serviceTypes, serviceType => Add(new ServiceHost(serviceType)));
            }
        }
    }
}
