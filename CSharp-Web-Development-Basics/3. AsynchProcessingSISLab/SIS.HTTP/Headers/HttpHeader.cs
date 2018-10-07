using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.Headers
{
    public class HttpHeader
    {
        private string key;
        private string value;

        public HttpHeader(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }

        public string Key
        {
            get { return this.key; }
            set { this.key = value; }
        }

        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public override string ToString()
        {
            return $"{this.Key}: {this.Value}";
        }
    }
}
