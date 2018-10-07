using System;
using System.Collections.Generic;
using System.Text;
using SIS.HTTP.Common;
using SIS.HTTP.Enums;
using SIS.HTTP.Extensions;
using SIS.HTTP.Headers;

namespace SIS.HTTP.Responses
{
    public class HttpResponse : IHttpResponse
    {
        public HttpResponse()
        {
        }

        public HttpResponse(HttpResponseStatusCode statusCode)
        {
            this.Headers = new HttpHeaderCollection();
            this.Content = new byte[0];
            this.StatusCode = statusCode;
        }

        public HttpResponseStatusCode StatusCode { get; set; }

        public IHttpHeaderCollection Headers { get; private set; }

        public byte[] Content { get; set; }

        public void AddHeader(HttpHeader header)
        {
            this.Headers.Add(header);
        }

        public byte[] GetBytes()
        {
            byte[] stringBytes = Encoding.ASCII.GetBytes(this.ToString());
            byte[] newBytes = new byte[this.Content.Length + stringBytes.Length];

            for (int i = 0; i < this.Content.Length; i++)
            {
                newBytes[i] = this.Content[i];
            }

            int index = 0;
            for (int i = this.Content.Length; i < newBytes.Length; i++)
            {
                newBytes[i] = stringBytes[index];
                index++;
            }

            return newBytes;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append($"{GlobalConstants.HttpOneProtocolFragment} {this.StatusCode.GetResponseLine()}").Append(Environment.NewLine)
                .Append(this.Headers.ToString()).Append(Environment.NewLine)
                .Append(Environment.NewLine);

            return result.ToString();
        }
    }
}
