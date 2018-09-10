using Chapter24.CustomerMaintenance.EventArgs;
using System;
using System.Windows.Forms;

namespace Chapter24.CustomerMaintenance.Controllers
{
    public interface IModuleController
    {
        Form Run();

        FormType GetView<FormType>();

        TServiceType GetService<TServiceType>();
    }
}