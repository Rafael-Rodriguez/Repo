using Chapter24.CustomerMaintenance.Model;
using System.Collections.Generic;
using System.Linq;

namespace Chapter24.CustomerMaintenance.Database
{
    public class StateRepository : IStateRepository
    {
        private MMABooksEntities _dbContext;
        private object _syncLock = new object();

        private MMABooksEntities DbContext
        {
            get
            {
                if (_dbContext == null)
                {
                    lock (_syncLock)
                    {
                        _dbContext = new MMABooksEntities();
                    }
                }

                return _dbContext;
            }
        }

        public List<State> GetStates()
        {
            return DbContext.States.OrderBy(state => state.StateName).ToList();
        }
    }
}
