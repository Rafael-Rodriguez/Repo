using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Chapter24.CustomerMaintenance.Perspectives.Extensions
{
    public static class TextBoxExtensions
    {
        public static bool IsPresent(this TextBox textBox)
        {
            return textBox != null && textBox.TextLength > 0 && textBox.Text != null;
        }

        public static bool IsInt32(this TextBox textBox)
        {
            return int.TryParse(textBox.Text, out int textBoxValue);
        }

        public static bool IsAlpha(this TextBox textBox)
        {
            Regex regex = new Regex("^[a-zA-Z]");
            return textBox != null && textBox.IsPresent() && regex.IsMatch(textBox.Text);
        }
    }
}
