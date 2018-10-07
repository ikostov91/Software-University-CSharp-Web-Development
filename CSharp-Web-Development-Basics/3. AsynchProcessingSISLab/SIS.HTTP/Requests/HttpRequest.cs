using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIS.HTTP.Cookies;
using SIS.HTTP.Enums;
using SIS.HTTP.Exceptions;
using SIS.HTTP.Extensions;
using SIS.HTTP.Headers;

namespace SIS.HTTP.Requests
{
    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new HttpHeaderCollection();
            this.Cookies = new HttpCookieCollection();

            this.ParseRequest(requestString);
        }

        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, object> FormData { get; }

        public Dictionary<string, object> QueryData { get; }

        public IHttpHeaderCollection Headers { get; }

        public IHttpCookieCollection Cookies { get; set; }

        public HttpRequestMethod RequestMethod { get; private set; }

        private bool IsValidRequestLine(string[] requestLine)
        {
            if (requestLine.Length == 3 || requestLine[2] == "HTTP/1.1")
            {
                return true;
            }

            return false;
        }

        private bool IsValidRequestQueryString(string queryString, string[] queryParameters)
        {
            if (string.IsNullOrEmpty(queryString) || queryParameters.Length >= 1)
            {
                return true;
            }

            return false;
        }

        private void ParseRequestMethod(string[] requestLine)
        {
            this.RequestMethod = (HttpRequestMethod)Enum.Parse(typeof(HttpRequestMethod), requestLine[0].Capitalize());
        }

        private void ParseRequestUrl(string[] requestLine)
        {
            this.Url = requestLine[1];
        }

        private void ParseRequestPath()
        {
            this.Path = this.Url.Split(new char[] { '?' }, StringSplitOptions.None).First();
        }

        private void ParseHeaders(string[] requestContent)
        {
            foreach (var line in requestContent)
            {
                if (line == "")
                {
                    break;
                }

                string[] headerContent = line.Split(new char[] { ':' });
                string key = string.Empty;
                string value = string.Empty;

                key = headerContent[0].Trim();
                if (key == "Host")
                {
                    value = (headerContent[1] + ':' + headerContent[2]).Trim();
                }
                else
                {
                    value = headerContent[1].Trim();
                }
                
                var header = new HttpHeader(key, value);

                this.Headers.Add(header);
            }

            if (!Headers.ContainsHeader("Host"))
            {
                throw new BadRequestException();
            }
        }

        private void ParseQueryParameters()
        {
            string queryString = this.Url.Split(new char[] { '?' }, StringSplitOptions.None).Last();

            if (queryString.Length == 1)
            {
                return;
            }

            string[] queryParameters = queryString.Split(new char[] { '&', '#' }, StringSplitOptions.None).TakeAllButLast();

            if (!IsValidRequestQueryString(queryString, queryParameters))
            {
                throw new BadRequestException();
            }

            foreach (var parameter in queryParameters)
            {
                string[] parameterKeyValue = parameter.Split(new char[] { '=' }, StringSplitOptions.None);
                string key = parameterKeyValue[0];
                string value = parameterKeyValue[1];

                this.QueryData.Add(key, value);
            }
        }

        private void ParseFormDataParameters(string formData)
        {
            if (string.IsNullOrEmpty(formData))
            {
                return;
            }

            string[] parameters = formData.Split(new char[] { '&' }, StringSplitOptions.None);

            foreach (var parameter in parameters)
            {
                string[] parameterKeyValue = parameter.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                string key = parameterKeyValue[0];
                string value = parameterKeyValue[1];

                this.FormData.Add(key, value);
            }
        }

        private void ParseRequestParameters(string formData)
        {
            this.ParseQueryParameters();
            this.ParseFormDataParameters(formData);
        }

        private void ParseCookies()
        {
            if (this.Headers.ContainsHeader("Cookie"))
            {
                HttpHeader header = this.Headers.GetHeader("Cookie");
                string value = header.Value;
            }
        }

        private void ParseRequest(string requestString)
        {
            string[] splitRequestContent = requestString.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            string[] requestLine = splitRequestContent[0].Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (!this.IsValidRequestLine(requestLine))
            {
                throw new BadRequestException();
            }

            this.ParseRequestMethod(requestLine);
            this.ParseRequestUrl(requestLine);
            this.ParseRequestPath();

            this.ParseHeaders(splitRequestContent.Skip(1).ToArray());
            this.ParseRequestParameters(splitRequestContent[splitRequestContent.Length - 1]);
        }
    }
}
