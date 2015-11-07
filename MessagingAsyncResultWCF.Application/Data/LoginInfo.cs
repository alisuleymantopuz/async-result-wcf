using System.Runtime.Serialization;

namespace MessagingAsyncResultWCF.Application.Data
{
    [DataContract]
    public class LoginInfo
    {
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}