using System.Net;

namespace DinnerInvite.Application.Common.Errors
{
    public interface IServiceException
    {
         public HttpStatusCode statusCode{get;}
         public string errorMessage { get; }
    }
}