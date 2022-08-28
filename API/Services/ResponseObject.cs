using System.Net;

namespace API.Services
{
    public class ResponseObject
    {
        //public string Status { get; set; }
        public string MessageTitle { get; set; }
        public string MessageDescription { get; set; }
        public object Data { get; set; }
        //public HttpStatusCode HttpStatusCode { get; set; }
        public string ResponseType { get; set; }
        /// <summary>
        /// error
        /// success
        /// na
        /// </summary>
        public enum Type
        {
            error,
            success,
            na
        }
    }
}
