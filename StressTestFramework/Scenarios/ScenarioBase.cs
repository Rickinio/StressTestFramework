using StressTestFramework.Actions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StressTestFramework.Scenarios
{
    public class ScenarioBase
    {
        private HttpClient _httpClient;
        public string _scenarioName;

        public ScenarioBase(string scenarioName)
        {
            _httpClient = new HttpClient();
            _scenarioName = scenarioName;
        }

        public virtual async Task Execute()
        {
            throw new NotImplementedException();
        }

        protected virtual async Task ExecuteAction(ActionBase action)
        {
            HttpResponseMessage response = null;
            switch (action.HttpVerb)
            {
                case Models.HttpVerb.Get:
                    response = await _httpClient.GetAsync(action.Endpoint);
                    break;
                case Models.HttpVerb.Post:
                    response = await _httpClient.PostAsync(action.Endpoint, new StringContent(action.Payload));
                    break;
                case Models.HttpVerb.Put:
                    response = await _httpClient.PutAsync(action.Endpoint, new StringContent(action.Payload));
                    break;
                case Models.HttpVerb.Delete:
                    response = await _httpClient.DeleteAsync(action.Endpoint);
                    break;
                default:
                    break;
            }

            action.Response = await response.Content.ReadAsStringAsync();
            action.HttpResponseHeaders = response.Headers;

            Debug.WriteLine($"Type of action: {action.GetType()}");
        }
    }
}
