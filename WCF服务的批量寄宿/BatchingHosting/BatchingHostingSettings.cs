using System.Configuration;

namespace Artech.BatchingHosting
{
    public class BatchingHostingSettings : ConfigurationSection
    {
        [ConfigurationProperty("", IsDefaultCollection = true)]
        public ServiceTypeElementCollection ServiceTypes
        {
            get { return (ServiceTypeElementCollection)this[""]; }
        }

        public static BatchingHostingSettings GetSection()
        {
            return ConfigurationManager.GetSection("artech.batchingHosting") as BatchingHostingSettings;
        }
    }
}
