using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegeditEmulator.Forms
{
    public partial class AddNodeForm : Form
    {
        public string nodeName { get; private set; }

        public AddNodeForm() {
            InitializeComponent();
        }

        public AddNodeForm(TreeNode node) {
            InitializeComponent();
            textBox.Text = node.Name;
        }

        private void buttonOK_Click(object sender, EventArgs e) {
            nodeName = textBox.Text;
            if (nodeName.IndexOfAny(new char[] { ':', ';', '\\' }) == -1) {
                DialogResult = DialogResult.OK;
            }
            else {
                MessageBox.Show("Remove special characters from name!");
            }
        }
    }
}
