using SimpleFormAPI.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFormAPI.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RepositoryContext _repositoryContext;
        private IUserRepository _user;
        private IEventLogRepository _eventLog;

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repositoryContext);
                }
                return _user;
            }
        }

        public IEventLogRepository EventLog
        {
            get
            {
                if (_eventLog == null)
                {
                    _eventLog = new EventLogRepository(_repositoryContext);
                }
                return _eventLog;
            }
        }

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
