using Chapter24.CustomerMaintenance.Model;
using System.Windows.Forms;

namespace Chapter24.CustomerMaintenance.Perspectives.Views
{
    public interface IfrmAddCustomer
    {
        Customer Customer { get; set; }

        DialogResult ShowDialog();
    }
}
