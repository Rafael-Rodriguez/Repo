using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Chapter24.CustomerMaintenance.Perspectives.Extensions
{
    public static class TextBoxExtensions
    {
        public static bool IsPresent(this TextBox textBox)
        {
            bool result = false;

            result = textBox.TextLength > 0 &&
                        textBox.Text != null;

            return result;
        }

        public static bool IsInt32(this TextBox textBox)
        {
            bool result = false;

            result = int.TryParse(textBox.Text, out int textBoxValue);

            return result;
        }

        public static bool IsAlphaOnly(this TextBox textBox)
        {
            Regex regex = new Regex("^[a-zA-Z ]+$");

            return regex.IsMatch(textBox.Text);
        }

        public static bool IsAlphaNumericOnly(this TextBox textBox)
        {
            Regex regex = new Regex("^[a-zA-Z0-9 ]+$");

            return regex.IsMatch(textBox.Text);
        }
    }
}
