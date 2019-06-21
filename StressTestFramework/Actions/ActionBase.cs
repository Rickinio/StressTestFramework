using StressTestFramework.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace StressTestFramework.Actions
{
    public class ActionBase
    {
        public string Response { get; set; }
        public HttpResponseHeaders HttpResponseHeaders { get; set; }

        private HttpVerb _httpVerb;
        public HttpVerb HttpVerb
        {
            get
            {
                if (_httpVerb != HttpVerb.None)
                {
                    return _httpVerb;
                }
                return GetHttpVerb();
            }
            set { this._httpVerb = value; }
        }

        public virtual HttpVerb GetHttpVerb()
        {
            throw new NotImplementedException();
        }

        private string _payload;
        public string Payload
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_payload))
                {
                    return _payload;
                }
                return GetEndpoint();
            }
            set { this._payload = value; }
        }

        public virtual string GetPayload()
        {
            throw new NotImplementedException();
        }

        private string _endPoint;
        public string Endpoint
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_endPoint))
                {
                    return _endPoint;
                }
                return GetEndpoint();
            }
            set { this._endPoint = value; }
        }

        public virtual string GetEndpoint()
        {
            throw new NotImplementedException();
        }
    }
}
