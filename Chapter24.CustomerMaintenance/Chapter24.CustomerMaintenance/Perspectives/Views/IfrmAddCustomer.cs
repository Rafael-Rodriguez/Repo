using Chapter24.CustomerMaintenance.Model;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Chapter24.CustomerMaintenance.Perspectives.Views
{
    public interface IfrmAddCustomer : IView
    {
        Customer Customer { get; set; }

        DialogResult ShowDialog();

        void InitializeStateComboBox(List<State> list);
    }
}
