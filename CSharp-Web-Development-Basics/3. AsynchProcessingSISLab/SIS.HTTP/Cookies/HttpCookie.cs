using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Serialization;

namespace SIS.HTTP.Cookies
{
    public  class HttpCookie
    {
        private const int HttpCookieDefaultExpirationDays = 3;

        public HttpCookie(string key, string value, int expires = HttpCookieDefaultExpirationDays)
        {
                
        }

        public HttpCookie(string key, string value, bool isNew, int expires = HttpCookieDefaultExpirationDays)
        {
            
        }

        public string Key { get; }

        public string Value { get; }

        public DateTime Expires { get; }

        public bool IsNew { get; }

        public override string ToString()
        {
            return $"{this.Key}={this.Value}; Expires={this.Expires.ToLongTimeString()}";
        }
    }
}
