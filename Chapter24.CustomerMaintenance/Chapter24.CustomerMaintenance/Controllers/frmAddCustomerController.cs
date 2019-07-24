using System;
using System.Windows.Forms;
using Chapter24.CustomerMaintenance.Database;
using Chapter24.CustomerMaintenance.Model;
using Chapter24.CustomerMaintenance.Perspectives.Views;

namespace Chapter24.CustomerMaintenance.Controllers
{
    public class frmAddCustomerController : Controller<IfrmAddCustomer>
    {
        private IStateRepository _stateRepository;
        private ICustomerRepository _customerRepository;
        private readonly object _syncLock = new object();

        internal frmAddCustomerController(IfrmAddCustomer view, IModuleController moduleController)
            : base(moduleController)
        {
            View = view;
        }

        internal frmAddCustomerController(IfrmAddCustomer view, IStateRepository stateRepository, ICustomerRepository customerRepository, IModuleController moduleController)
            : base(moduleController)
        {
            View = view;
            _customerRepository = customerRepository;
            _stateRepository = stateRepository;
        }

        private IStateRepository StateRepository
        {
            get
            {
                if(_stateRepository == null)
                {
                    lock(_syncLock)
                    {
                        if(_stateRepository == null)
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
                if(_customerRepository == null)
                {
                    lock(_syncLock)
                    {
                        if(_customerRepository == null)
                        {
                            _customerRepository = new CustomerRepository();
                        }
                    }
                }

                return _customerRepository;
            }
        }

        internal void OnLoad()
        {
            LoadStateComboBox();
        }

        internal bool AddCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            if(!CustomerRepository.AddCustomer(customer))
            {
                MessageBox.Show(Properties.Resources.ErrorUnableToAddCustomer);
                return false;
            }

            return true;
        }

        private void LoadStateComboBox()
        {
            View.InitializeStateComboBox(StateRepository.GetStates());
        }
    }
}
