using MessagingAsyncResultWCF.Application.Data;
using System;
using System.ServiceModel;

namespace MessagingAsyncResultWCF.Application
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILoginService" in both code and config file together.
    [ServiceContract]
    public interface ILoginService
    {
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginLoginOperation(LoginInfo loginInfo, AsyncCallback callback, object state);
        LoginAsyncResult EndLoginOperation(IAsyncResult asyncResult);
    }
}
