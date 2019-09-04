using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Demo.Server.Svc
{
    public class WCFUtil
    {

        public static ServiceHost Run<T1, T2>(string uri)
        {
            Uri httpBaseAddress = new Uri(uri);

            ServiceHost serviceHost = new ServiceHost(typeof(T1), httpBaseAddress);
            serviceHost.Description.Behaviors.Remove(typeof(ServiceDebugBehavior));
            serviceHost.Description.Behaviors.Add(new ServiceDebugBehavior { IncludeExceptionDetailInFaults = true });

            BasicHttpBinding basicHttpBinding = new BasicHttpBinding
            {
                MaxReceivedMessageSize = int.MaxValue,
                MaxBufferSize = int.MaxValue,
                MaxBufferPoolSize = int.MaxValue,
                ReceiveTimeout = new TimeSpan(int.MaxValue),
                SendTimeout = TimeSpan.MaxValue,
                TransferMode = TransferMode.Buffered,
                ReaderQuotas = XmlDictionaryReaderQuotas.Max
            };

            serviceHost.AddServiceEndpoint(typeof(T2), basicHttpBinding, httpBaseAddress);

            ServiceMetadataBehavior serviceBehavior = new ServiceMetadataBehavior { HttpGetEnabled = true };
            serviceHost.Description.Behaviors.Add(serviceBehavior);

            serviceHost.Open();
            Console.WriteLine("WCF is live now at: {0}", httpBaseAddress);

            return serviceHost;
        }
    }
}

//T1: WCF, T2: IWCF

public class WCFHandler<T1>
{
    private static T1 _channelS = default(T1);
    private static ChannelFactory<T1> _channelFactoryS = default(ChannelFactory<T1>);

    public static T1 Channel(string wcfCommonEndPoint)
    {
        if (_channelS != null)
        {
            return _channelS;
        }
        var binding = GetClientBinding();
        EndpointAddress endpoint = new EndpointAddress(wcfCommonEndPoint);
        ChannelFactory<T1> factory = new ChannelFactory<T1>(binding, endpoint);
        T1 channel = factory.CreateChannel();

        _channelS = channel;
        return channel;
    }

    public static ChannelFactory<T1> ChannelFactory(string wcfCommonEndPoint)
    {
        var binding = GetClientBinding();
        EndpointAddress endpoint = new EndpointAddress(wcfCommonEndPoint);
        ChannelFactory<T1> factory = new ChannelFactory<T1>(binding, endpoint);

        return factory;
    }

    private static CustomBinding GetClientBinding()
    {

        BasicHttpBinding binding = new BasicHttpBinding
        {
            MaxReceivedMessageSize = int.MaxValue,
            MaxBufferPoolSize = int.MaxValue,
            MaxBufferSize = int.MaxValue,
            ReceiveTimeout = TimeSpan.FromSeconds(5),
            //ReceiveTimeout = TimeSpan.MaxValue,
            TransferMode = TransferMode.Buffered,
            //SendTimeout = TimeSpan.FromSeconds(15),
            SendTimeout = TimeSpan.FromSeconds(20),
            ReaderQuotas = XmlDictionaryReaderQuotas.Max
        };


        var customBinding = new CustomBinding(binding);
        var transportElement = customBinding.Elements.Find<HttpTransportBindingElement>();
        transportElement.KeepAliveEnabled = false;

        return customBinding;
    }
}

