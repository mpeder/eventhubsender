using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHubSender
{
    class LogEntry
    {
        public string User { get; set; }
        public string Customer { get; set; }

        public string Action { get; set; }

        public DateTime Timestamp { get; set; }

        public int Severity { get; set; }

        public Guid Id { get; set; }


    }
}
