using Chapter24.CustomerMaintenance.Model;
using System.Collections.Generic;

namespace Chapter24.CustomerMaintenance.Database
{
    public interface IStateRepository
    {
        List<State> GetStates();
    }
}
