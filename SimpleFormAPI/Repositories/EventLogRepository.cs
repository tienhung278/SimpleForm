using SimpleFormAPI.Contracts;
using SimpleFormAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFormAPI.Repositories
{
    public class EventLogRepository : RepositoryBase<EventLog>, IEventLogRepository
    {
        public EventLogRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }

        public void CreateEventLog(EventLog eventLog)
        {
            Create(eventLog);
        }

        public ICollection<EventLog> GetEventLogByTransaction(Guid id)
        {
            return FindByCondition(e => e.TransactionId == id)
                .OrderByDescending(e => e.CreatedAt)
                .ToList();                 
        }
    }
}
