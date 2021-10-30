using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFormAPI.Models
{
    public class EventLog
    {
        public Guid Id { get; set; }
        public Action Event { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid TransactionId { get; set; }
        public string Information { get; set; }
    }

    public enum Action
    {
        Add,
        Update,
        Delete
    }
}
