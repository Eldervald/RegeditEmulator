using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RegeditEmulator;
using Microsoft.Win32;

namespace RegeditEmulator.Forms
{
    public partial class AddKeyForm : Form
    {
        public Key Key { get; private set; }

        public AddKeyForm() {
            Init();
        }

        public AddKeyForm(Key key) {
            Init();
            textBoxName.Text = key.Name;
            textBoxValue.Text = key.Value;
            typeBox.SelectedIndex = (int)key.Type;
        }

        private void Init() {
            InitializeComponent();
            typeBox.DataSource = Enum.GetValues(typeof(RegistryValueKind));
            typeBox.SelectedIndex = 0;
        }

        private void buttonOK_Click(object sender, EventArgs e) {
            string name, value;
            string error = "";
            RegistryValueKind type;
            name = textBoxName.Text;
            DialogResult = DialogResult.OK;
            if (name.IndexOfAny(new char[] { ':', ';', '\\' }) != -1) {
                DialogResult = DialogResult.Retry;
                error += "Remove special characters from name!\n";
            }
            value = textBoxValue.Text;
            if (value.IndexOfAny(new char[] { ':', ';', '\\' }) != -1) {
                DialogResult = DialogResult.Retry;
                error += "Remove special characters from value!\n";
            }
            type = (RegistryValueKind)typeBox.SelectedIndex;

            if (DialogResult == DialogResult.Retry) {
                MessageBox.Show(error);
            }

            if (DialogResult == DialogResult.OK) {
                Key = new Key(name, type, value);
            }
        }
    }
}
