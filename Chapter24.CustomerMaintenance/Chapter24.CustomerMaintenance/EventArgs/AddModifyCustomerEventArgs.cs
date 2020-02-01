namespace Chapter24.CustomerMaintenance.EventArgs
{
    public class AddModifyCustomerEventArgs : System.EventArgs
    {
        public enum AddModify
        {
            Add,
            Modify
        };

        public AddModify AddOrModify;
    }
}
