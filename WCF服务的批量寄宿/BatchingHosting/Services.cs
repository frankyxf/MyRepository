using System.ServiceModel;

namespace Fred.WcfServiceBatchHosting
{
    [ServiceContract(Namespace = "http://www.artech.com")]
    public interface IFoo
    {
        [OperationContract]
        void Doth();
    }

    [ServiceContract(Namespace = "http://www.artech.com")]
    public interface IBar
    {
        [OperationContract]
        void Doth();
    }

    [ServiceContract(Namespace = "http://www.artech.com")]
    public interface IBaz
    {
        [OperationContract]
        void Doth();
    }

    public class FooService : IFoo
    {
        public void Doth() { }
    }

    public class BarService : IBar
    {
        public void Doth() { }
    }

    public class BazService : IBaz
    {
        public void Doth() { }
    }
}
