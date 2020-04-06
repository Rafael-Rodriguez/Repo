using Chapter24.CustomerMaintenance.Perspectives;
using Chapter24.CustomerMaintenance.Perspectives.Views;
using Chapter24.CustomerMaintenance.Services;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Chapter24.CustomerMaintenance.Controllers
{
    public class ModuleController : IModuleController
    {
        private List<IView> _views;
        private List<IService> _services;


        public Form Run()
        {
            RegisterViews();

            RegisterServices();

            return GetView<frmCustomerDisplay>();
        }

        public TFormType GetView<TFormType>()
        {
            return _views.OfType<TFormType>().Single();
        }

        public TServiceType GetService<TServiceType>()
        {
            return _services.OfType<TServiceType>().Single();
        }

        private void RegisterViews()
        {
            _views = new List<IView>()
            {
                new frmCustomerDisplay(this),
                new frmAddCustomer(this),
                new frmModifyCustomer(this)
            };
        }

        private void RegisterServices()
        {
            _services = new List<IService>()
            {
                new ProgramFlowManager(this)
            };
        }
    }
}
