using System.Collections.Generic;
using System.Windows.Forms;
using Chapter24.CustomerMaintenance.Model;

namespace Chapter24.CustomerMaintenance.Perspectives.Views
{
    public interface IfrmModifyCustomer : IView
    {
        Customer Customer { get; set; }

        DialogResult ShowDialog();

        void InitializeStateComboBox(List<State> states);

        void DisplayCustomer(Customer customer);
    }
}
