namespace Chapter24.CustomerMaintenance.Perspectives.Components
{
    public class MessageBox : IMessageBox
    {
        public void Show(string message, string text)
        {
            System.Windows.Forms.MessageBox.Show(message, text);
        }
    }
}
