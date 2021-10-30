using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFormAPI.Contracts
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IEventLogRepository EventLog { get; }
        void Save();
    }
}
