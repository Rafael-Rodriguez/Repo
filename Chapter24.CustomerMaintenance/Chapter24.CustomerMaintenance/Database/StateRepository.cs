using Chapter24.CustomerMaintenance.Model;
using System.Collections.Generic;
using System.Linq;

namespace Chapter24.CustomerMaintenance.Database
{
    public class StateRepository : IStateRepository
    {
        public List<State> GetStates()
        {
            return MMABooksEntity.Instance.DbContext.States.OrderBy(state => state.StateName).ToList();
        }
    }
}
