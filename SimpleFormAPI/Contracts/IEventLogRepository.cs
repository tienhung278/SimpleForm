using SimpleFormAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFormAPI.Contracts
{
    public interface IEventLogRepository
    {
        ICollection<EventLog> GetEventLogByTransaction(Guid id);
        void CreateEventLog(EventLog eventLog);
    }
}
