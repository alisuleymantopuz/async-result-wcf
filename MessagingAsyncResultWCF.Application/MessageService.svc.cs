using System;
using System.Threading;

namespace MessagingAsyncResultWCF.Application
{
    public class MessageService : IMessageService
    {
        public IAsyncResult BeginGetMessage(string message, AsyncCallback callback, object state)
        {
            var replyMessage = string.Format("{0}{1}", "Server says :", message);
            
            var messageAsyncResult = new MessageAsyncResult(replyMessage, callback, state);
            
            ThreadPool.QueueUserWorkItem(CompleteProcess, messageAsyncResult);
            
            return messageAsyncResult;
        }

        public string EndGetMessage(IAsyncResult asyncResult)
        {
            var messageAsyncResult = asyncResult as MessageAsyncResult;

            messageAsyncResult.AsyncWait.WaitOne();
            
            return messageAsyncResult.Message;
        }


        private void CompleteProcess(object state)
        {
            var messageAsyncResult = state as MessageAsyncResult;

            messageAsyncResult.Completed();
        }
    }
}
