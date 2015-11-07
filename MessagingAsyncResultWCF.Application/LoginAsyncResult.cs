using MessagingAsyncResultWCF.Application.Data;
using System;
using System.Runtime.Serialization;

namespace MessagingAsyncResultWCF.Application
{
    [DataContract]
    public class LoginAsyncResult : AsyncResult
    {
        [DataMember]
        public LoginInfo LoginInfo { get; set; }

        [DataMember]
        public bool LoginSuccessStatus { get; set; }

        public LoginAsyncResult(LoginInfo loginInfo, bool loginStatus, AsyncCallback callback, object state)
            : base(callback, state)
        {
            LoginInfo = loginInfo;

            LoginSuccessStatus = loginStatus;
        }
    }
}