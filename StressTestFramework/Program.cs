using StressTestFramework.Scenarios;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StressTestFramework
{
    class Program
    {
        public BlockingCollection<ScenarioBase> _scenarioQueue = new BlockingCollection<ScenarioBase>();
        public List<Task> _scenarioTasks = new List<Task>();

        static async Task Main(string[] args)
        {
            var program = new Program();            
            program.StartProcessing();

            var i = 10;
            while (i != 0)
            {
                await Task.Delay(500);
                program.Enqueue(new SocialMediaScenario());

                i--;
            }

            program.WaitAllScenarios();

            Console.WriteLine("All scenarions finished");

            Console.ReadKey();
        }

        public void WaitAllScenarios()
        {
            Task.WaitAll(_scenarioTasks.ToArray());
        }

        public void StartProcessing()
        {
            var thread = new Thread(ProcessQueue)
            {
                // This is important as it allows the process to exit while this thread is running
                IsBackground = true
            };
            thread.Start();
        }

        public void Enqueue(ScenarioBase scenario)
        {
            _scenarioQueue.Add(scenario);
        }

        public void ProcessQueue()
        {
            foreach (var item in _scenarioQueue.GetConsumingEnumerable())
            {
                var task = ProcessItem(item);
                _scenarioTasks.Add(task);
            }
        }

        private async Task ProcessItem(ScenarioBase scenario)
        {
            await scenario.Execute();
        }

        
    }
}
