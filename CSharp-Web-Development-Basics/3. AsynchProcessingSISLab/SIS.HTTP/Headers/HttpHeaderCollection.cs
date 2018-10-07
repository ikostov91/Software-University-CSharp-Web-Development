using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.Headers
{
    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void Add(HttpHeader header)
        {
            //// implement if contains
            this.headers.Add(header.Key, header);
        }

        public bool ContainsHeader(string key)
        {
            return this.headers.ContainsKey(key);
        }

        public HttpHeader GetHeader(string key)
        {
            if (this.headers.ContainsKey(key))
            {
                return this.headers[key];
            }
            else
            {
                return null;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (var header in this.headers)
            {
                result.Append(header.ToString() + Environment.NewLine);
            }

            return result.ToString().Trim();
        }
    }
}
