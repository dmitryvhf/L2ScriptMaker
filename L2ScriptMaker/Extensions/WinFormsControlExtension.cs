using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L2ScriptMaker.Extensions
{
    public class SelectedItem
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }

    public static class WinFormsControlExtension
    {
        public static void SelectItembyValue(this ComboBox comboBox, string value)
        {
            comboBox.SelectedIndex = -1;

            SelectedItem foundItem = comboBox.Items.OfType<SelectedItem>().FirstOrDefault(a => a.Value == value);
            if (foundItem == null) return;
            
            comboBox.SelectedItem = foundItem;
        }
    }
}
