using SimpleFormAPI.Contracts;
using SimpleFormAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SimpleFormAPI.Services
{
    public class EventLogServices
    {
        private readonly IEventLogRepository _eventLogRepository;

        public EventLogServices(IEventLogRepository eventLogRepository)
        {
            _eventLogRepository = eventLogRepository;
        }

        public void CreateEventLog<T>(Models.Action action, T obj) where T : class
        {
            _eventLogRepository.CreateEventLog(new EventLog
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                Event = action,
                Information = JsonSerializer.Serialize(obj),
                TransactionId = Guid.NewGuid()
            });
        }
    }
}
