using Microsoft.Azure.EventHubs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHubSender
{
    class Program
    {
        static void Main(string[] args)
        {
            var sendMsg = true;

            while (sendMsg)
            {
                var eventHubClient = EventHubClient.CreateFromConnectionString("INSERT");

                
                

                LogEntry log1 = new LogEntry();
                log1.Action = "Read Birthdate";
                log1.Customer = "Contoso";
                log1.Severity = 2;
                log1.Timestamp = DateTime.Now;
                log1.User = "Rasmus";
                log1.Id = Guid.NewGuid();

                LogEntry log2 = new LogEntry();
                log2.Action = "Read SSN";
                log2.Customer = "Microsoft";
                log2.Severity = 1;
                log2.Timestamp = DateTime.Now;
                log2.User = "Michael";
                log2.Id = Guid.NewGuid();

                string msg1 = JsonConvert.SerializeObject(log1);
                string msg2 = JsonConvert.SerializeObject(log2);

                // Create a new EventData object by encoding a string as a byte array
                var data1 = new EventData(Encoding.UTF8.GetBytes(msg1));
                var data2 = new EventData(Encoding.UTF8.GetBytes(msg2));

                data1.Properties.Add("Type", "Other");
                data2.Properties.Add("Type", "GDPR");

                // Send single message async
                eventHubClient.SendAsync(data1);
                eventHubClient.SendAsync(data2);

                Console.WriteLine("Sent: " + msg1);
                Console.WriteLine("Sent: " + msg2);


                string res = Console.ReadLine();
                if (res == "q")
                {
                    sendMsg = false;
                }
            }

            

        }
    }
}
