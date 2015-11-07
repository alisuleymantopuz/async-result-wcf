using System;
using System.ServiceModel;

namespace MessagingAsyncResultWCF.Application
{
    [ServiceContract]
    public interface IMessageService
    {
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginGetMessage(string message, AsyncCallback callback, object state);
        string EndGetMessage(IAsyncResult asyncResult);
    }


    
}
