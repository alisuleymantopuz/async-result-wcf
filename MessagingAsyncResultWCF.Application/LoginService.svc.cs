using MessagingAsyncResultWCF.Application.Data;
using MessagingAsyncResultWCF.Application.Helper;
using System;
using System.Threading;

namespace MessagingAsyncResultWCF.Application
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LoginService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LoginService.svc or LoginService.svc.cs at the Solution Explorer and start debugging.
    public class LoginService : ILoginService
    {
        public IAsyncResult BeginLoginOperation(LoginInfo loginInfo, AsyncCallback callback, object state)
        {
            var loginAsyncResult = new LoginAsyncResult(loginInfo, false, callback, state);

            ThreadPool.QueueUserWorkItem(CompleteProcess, loginAsyncResult);

            return loginAsyncResult;
        }

        public LoginAsyncResult EndLoginOperation(IAsyncResult asyncResult)
        {
            var loginAsyncResult = asyncResult as LoginAsyncResult;

            loginAsyncResult.AsyncWait.WaitOne();

            return loginAsyncResult;
        }

        private void CompleteProcess(object state)
        {
            var loginAsyncResult = state as LoginAsyncResult;

            var isUserLoginSuccess = LoginHelper.CheckLogin(loginAsyncResult.LoginInfo);

            loginAsyncResult.LoginSuccessStatus = isUserLoginSuccess;

            loginAsyncResult.Completed();
        }
    }
}
