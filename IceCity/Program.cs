
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IceCity
{
   
    
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("    IceCity: System Operations & Diagnostics      ");
            Console.WriteLine("==================================================\n");

           
            Owner owner = new Owner("Ahmed");
            House mainHouse = new House(owner);
            CityCenterService cityCenter = new CityCenterService();
            WeatherService weatherApi = new WeatherService();

           
            HeaterBase? currentHeater = new ElectricHeater(1500);
            mainHouse.AddHeater(currentHeater);

            
            SaveDailyUsageDelegate saveUsageHandler = (usage) =>
            {
                mainHouse.AddDailyUsage(usage);
                Console.WriteLine($"[Delegate] Saved usage: Date {usage.Date:yyyy-MM-dd}, Hours {usage.WorkingHours:F1}");
            };

            
            SubscribeToHeaterEvents(currentHeater, saveUsageHandler);

           
            Console.WriteLine("--- Phase 1: Heater Operations & Failure Simulation ---");

            for (int i = 1; i <= 5; i++)
            {
               
                if (currentHeater == null)
                {
                    Console.WriteLine("[System] Heater slot is currently empty (null). Skipping operation.");
                    continue;
                }

                try
                {
                    Console.WriteLine($"\n> Attempt {i}: Turning heater ON...");
                    currentHeater.Open();

                    Thread.Sleep(500); 

                    Console.WriteLine($"> Attempt {i}: Turning heater OFF...");
                    currentHeater.Close();
                }
                catch (HeaterFailedException ex)
                {
                   
                    Console.WriteLine($"\n[ALARM] {ex.Message}");

                    
                    HeaterBase brokenHeater = currentHeater;

                    
                    currentHeater = null;
                    mainHouse.ReplaceHeater(0, null);
                    Console.WriteLine("[System] Broken heater removed. Current slot is null.");

                    
                    var newHeater = await cityCenter.RequestReplacementAsync(mainHouse.HouseId, brokenHeater);

                   
                    currentHeater = newHeater;
                    mainHouse.ReplaceHeater(0, currentHeater);
                    SubscribeToHeaterEvents(currentHeater, saveUsageHandler);
                }
            }

            
            Console.WriteLine("\n--- Phase 2: Async Weather Data Fetching ---");
            if (currentHeater != null)
            {
                var apiUsages = await weatherApi.FetchLastMonthWeatherAsync(currentHeater);

                Console.WriteLine("\n--- Phase 3: Printing with THREADS ---");
                PrintLastMonthDailyUsageWithThreads(apiUsages);

                Console.WriteLine("\n--- Phase 4: Printing with TASKS ---");
                await PrintLastMonthDailyUsageWithTasksAsync(apiUsages);
            }

            Console.WriteLine("\n==================================================");
            Console.WriteLine("        System Simulation Completed Successfully.   ");
            Console.WriteLine("==================================================");
            Console.ReadKey();
        }

        

        static void SubscribeToHeaterEvents(HeaterBase? heater, SaveDailyUsageDelegate saveAction)
        {
            if (heater == null) return;

            heater.OpenHeater += (sender, e) =>
                Console.WriteLine($"[Event] Heater {e.Heater.HeaterId} has STARTED.");

            heater.CloseHeater += (sender, e) =>
            {
                Console.WriteLine($"[Event] Heater STOPPED. Calculated Duration: {e.HoursWorked:F2} seconds.");
                saveAction(new DailyUsage(DateTime.UtcNow.Date, e.HoursWorked, e.Heater));
            };
        }

        static void PrintLastMonthDailyUsageWithThreads(IEnumerable<DailyUsage> usageList)
        {
            var t1 = new Thread(() => PrintUsageWithId(usageList, "Thread"));
            var t2 = new Thread(() => PrintUsageWithId(usageList, "Thread"));

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();
        }

        static async Task PrintLastMonthDailyUsageWithTasksAsync(IEnumerable<DailyUsage> usageList)
        {
            var tasks = new[] {
                Task.Run(() => PrintUsageWithId(usageList, "Task")),
                Task.Run(() => PrintUsageWithId(usageList, "Task"))
            };

            await Task.WhenAll(tasks);
        }

        static void PrintUsageWithId(IEnumerable<DailyUsage> usages, string mode)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            int? taskId = Task.CurrentId;

            string workerInfo = mode == "Task" ? $"Task={taskId}, Thread={threadId}" : $"Thread={threadId}";

            foreach (var u in usages)
            {
                lock (Console.Out)
                {
                    Console.WriteLine($"{u.Date:yyyy-MM-dd} | HeaterVal={u.HeaterValue} | Hours={u.WorkingHours:F1} | {workerInfo}");
                }
            }
        }
    }
}