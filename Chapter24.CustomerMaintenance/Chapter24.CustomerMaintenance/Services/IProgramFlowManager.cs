using Chapter24.CustomerMaintenance.Model;

namespace Chapter24.CustomerMaintenance.Services
{
    public interface IProgramFlowManager : IService
    {
        Customer AddNewCustomer();
    }
}
