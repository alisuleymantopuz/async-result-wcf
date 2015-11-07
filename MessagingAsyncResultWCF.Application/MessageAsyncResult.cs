using System;

namespace MessagingAsyncResultWCF.Application
{
    public class MessageAsyncResult : AsyncResult
    {
        public string Message { get; private set; }

        public MessageAsyncResult(string message, AsyncCallback callback, object state): base(callback, state)
        {
            Message = message;
        }
    }
}