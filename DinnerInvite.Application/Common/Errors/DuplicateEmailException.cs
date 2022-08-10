using System;
using System.Net;

namespace DinnerInvite.Application.Common.Errors
{
    public class DuplicateEmailException : Exception, IServiceException
    {
        public HttpStatusCode statusCode => HttpStatusCode.Conflict;

        public string errorMessage => "Email Already Exists.";
    }
}