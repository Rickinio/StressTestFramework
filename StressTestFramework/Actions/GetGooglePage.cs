using System;
using System.Collections.Generic;
using System.Text;
using StressTestFramework.Models;

namespace StressTestFramework.Actions
{
    public class GetGooglePage : ActionBase
    {
        public override string GetPayload()
        {
            return base.GetPayload();
        }

        public override string GetEndpoint()
        {
            return "https://www.google.com";
        }

        public override HttpVerb GetHttpVerb()
        {
            return HttpVerb.Get;
        }
    }
}
