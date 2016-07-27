
using System.Net;

namespace MaybeSomethingCOOL.http
{
    public interface IHttpRequestResponse
    {
        string GetResponse(HttpWebRequest request);
        HttpWebRequest GetRequest(string fullUrl, string authorizationHeaderParams, string method);
    }
}
