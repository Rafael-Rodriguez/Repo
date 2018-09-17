using Chapter24.CustomerMaintenance.Database;
using Chapter24.CustomerMaintenance.Perspectives.Views;

namespace Chapter24.CustomerMaintenance.Controllers
{
    public class frmAddCustomerController : Controller<IfrmAddCustomer>
    {
        private IfrmAddCustomer _view;
        private IStateRepository _stateRepository;
        private readonly object _syncLock = new object();

        internal frmAddCustomerController(IfrmAddCustomer view, IModuleController moduleController)
            : base(moduleController)
        {
            View = view;
        }

        internal frmAddCustomerController(IfrmAddCustomer view, IStateRepository stateRepository, IModuleController moduleController)
            : base(moduleController)
        {
            View = view;
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

        internal void OnLoad()
        {
            LoadStateComboBox();
        }

        private void LoadStateComboBox()
        {
            View.InitializeStateComboBox(StateRepository.GetStates());
        }
    }
}
