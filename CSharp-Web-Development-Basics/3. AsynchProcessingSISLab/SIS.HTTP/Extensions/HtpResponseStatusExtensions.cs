using SIS.HTTP.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.Extensions
{
    public static class HtpResponseStatusExtensions
    {
        public static string GetResponseLine(this HttpResponseStatusCode statusCode)
        {
            string responseLine = string.Empty;

            switch (statusCode)
            {
                case HttpResponseStatusCode.Ok:
                    responseLine = "200 OK";
                    break;
                case HttpResponseStatusCode.Created:
                    responseLine = "201 Created";
                    break;
                case HttpResponseStatusCode.Found:
                    responseLine = "302 Found";
                    break;
                case HttpResponseStatusCode.SeeOther:
                    responseLine = "303 See other";
                    break;
                case HttpResponseStatusCode.BadRequest:
                    responseLine = "400 Bad Request";
                    break;
                case HttpResponseStatusCode.Unauthorized:
                    responseLine = "401 Unauthorized";
                    break;
                case HttpResponseStatusCode.Forbidden:
                    responseLine = "403 Forbidden";
                    break;
                case HttpResponseStatusCode.NotFound:
                    responseLine = "404 Not Found";
                    break;
                case HttpResponseStatusCode.InternalServerError:
                    responseLine = "500 Internal Server Error";
                    break;
            }

            return responseLine;
        }
    }
}
