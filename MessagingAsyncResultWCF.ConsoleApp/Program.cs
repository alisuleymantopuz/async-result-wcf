using MessagingAsyncResultWCF.Application;
using MessagingAsyncResultWCF.Application.Data;
using System;
using System.ServiceModel;

namespace MessagingAsyncResultWCF.ConsoleApp
{
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var channelFactory = new ChannelFactory<IMessageService>("MessageServiceEndpoint");

    //        var proxy = channelFactory.CreateChannel();

    //        var message = Console.ReadLine();

    //        while (!message.Equals("exit", StringComparison.CurrentCultureIgnoreCase))
    //        {
    //            proxy.BeginGetMessage(message, ClientCallBack, proxy);
    //            message = Console.ReadLine();
    //        }
    //    }

    //    private static void ClientCallBack(IAsyncResult ar)
    //    {
    //        var response = ar.AsyncState as IMessageService;
    //        if (response != null)
    //        {
    //            var message = response.EndGetMessage(ar);
    //            Console.WriteLine(message);
    //        }
    //    }
    //}

    class Program
    {
        static void Main(string[] args)
        {
            var channelFactory = new ChannelFactory<ILoginService>("LoginServiceEndpoint");

            var proxy = channelFactory.CreateChannel();
            
            for (int i = 0; i < 1000; i++)
            {
                proxy.BeginLoginOperation(new LoginInfo() { Password = "", Username = i.ToString() }, ClientCallBack, proxy);
            
            }

            Console.ReadLine();
        }

        private static void ClientCallBack(IAsyncResult ar)
        {
            var response = ar.AsyncState as ILoginService;
            if (response != null)
            {
                var loginAsyncResult = response.EndLoginOperation(ar);
                Console.WriteLine(string.Format("Login Name  : {0}, Login status : {1}", loginAsyncResult.LoginInfo.Username,loginAsyncResult.LoginSuccessStatus));
            }
        }
    }
}
