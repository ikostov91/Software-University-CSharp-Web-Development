using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIS.HTTP.Cookies
{
    public class HttpCookieCollection : IHttpCookieCollection
    {
        private readonly Dictionary<string, HttpCookie> cookies;

        public HttpCookieCollection()
        {
            this.cookies = new Dictionary<string, HttpCookie>();        
        }

        public void Add(HttpCookie cookie)
        {
            this.cookies.Add(cookie.Key, cookie);
        }

        public bool ContainsCookie(string key)
        {
            return this.cookies.ContainsKey(key);
        }

        public HttpCookie GetCookie(string key)
        {
            if (this.cookies.ContainsKey(key))
            {
                return this.cookies[key];
            }
            else
            {
                return null;
            }
        }

        public bool HasCookies()
        {
            return this.cookies.Any();
        }

        public override string ToString()
        {
            return string.Join("; ", this.cookies.Values);
        }
    }
}
