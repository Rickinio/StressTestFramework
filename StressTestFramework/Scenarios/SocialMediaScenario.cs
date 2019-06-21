using StressTestFramework.Actions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace StressTestFramework.Scenarios
{
    public class SocialMediaScenario : ScenarioBase
    {
        public SocialMediaScenario()
            :base(nameof(SocialMediaScenario))
        {
        }

        public override async Task Execute()
        {
            var getGooglePage = new GetGooglePage();
            await this.ExecuteAction(getGooglePage);

            Debug.WriteLine(getGooglePage.Response);
            if (getGooglePage.HttpResponseHeaders != null)
            {
                foreach (var header in getGooglePage.HttpResponseHeaders)
                {
                    Debug.WriteLine($"header: {header.Key} - {header.Value}");
                }
            }
        }

    }
}
