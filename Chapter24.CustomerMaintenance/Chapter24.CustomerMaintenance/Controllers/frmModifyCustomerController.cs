using Chapter24.CustomerMaintenance.Database;
using Chapter24.CustomerMaintenance.Model;
using Chapter24.CustomerMaintenance.Perspectives.Views;

namespace Chapter24.CustomerMaintenance.Controllers
{
    public class frmModifyCustomerController : Controller<IfrmModifyCustomer>
    {
        private readonly object _syncLock = new object();
        private IStateRepository _stateRepository;
        private ICustomerRepository _customerRepository;

        internal frmModifyCustomerController(IfrmModifyCustomer view, IModuleController _moduleController)
            : base(_moduleController)
        {
            View = view;
        }

        private IStateRepository StateRepository
        {
            get
            {
                if (_stateRepository == null)
                {
                    lock (_syncLock)
                    {
                        if (_stateRepository == null)
                        {
                            _stateRepository = new StateRepository();
                        }
                    }
                }

                return _stateRepository;
            }
        }

        private ICustomerRepository CustomerRepository
        {
            get
            {
                if (_customerRepository == null)
                {
                    lock (_syncLock)
                    {
                        if (_customerRepository == null)
                        {
                            _customerRepository = new CustomerRepository();
                        }
                    }
                }

                return _customerRepository;
            }
        }


        public void OnLoad(Customer customer)
        {
            LoadStateComboBox();
            View.DisplayCustomer(customer);
        }

        private void LoadStateComboBox()
        {
            View.InitializeStateComboBox(StateRepository.GetStates());
        }

        public SaveChangesResult ModifyCustomer(Customer customer)
        {
            return CustomerRepository.SaveChanges(customer);
        }
    }
}
