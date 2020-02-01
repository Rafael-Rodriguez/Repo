using Chapter24.CustomerMaintenance.Model;

namespace Chapter24.CustomerMaintenance.EventArgs
{
    public class CustomerAddedEventArgs : System.EventArgs
    {
        public Customer Customer { get; set; }
    }
}
