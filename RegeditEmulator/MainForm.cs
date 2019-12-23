using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using RegeditEmulator.Forms;

namespace RegeditEmulator
{
    public partial class MainForm : Form
    {
        private TreeNode Computer = new TreeNode("Computer");
        private RegistryKey HKLM = Registry.LocalMachine;
        private RegistryKey CU = Registry.CurrentUser;
        private RegistryKey CR = Registry.ClassesRoot;
        private RegistryKey Users = Registry.Users;
        private RegistryKey CC = Registry.CurrentConfig;


        public MainForm() {
            InitializeComponent();
            Initialize();
        }

        private void Initialize() {
            Computer.Nodes.Add(new TreeNode(CR.Name) { Tag = CR });
            Computer.Nodes.Add(new TreeNode(CU.Name) { Tag = CU });
            Computer.Nodes.Add(new TreeNode(HKLM.Name) { Tag = HKLM });
            Computer.Nodes.Add(new TreeNode(Users.Name) { Tag = Users });
            Computer.Nodes.Add(new TreeNode(CC.Name) { Tag = CC });
            treeView.Nodes.Add(Computer);
            treeView.Nodes[0].Expand();
        }

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {
            treeView.SelectedNode = e.Node;
            UpdateTreeView();

            if (e.Button == MouseButtons.Left) {
                UpdateKeysView(e.Node); 
            }
            else if (e.Button == MouseButtons.Right) {
                if (e.Node.Level == 0) {
                    NodeContextMenu.Items[0].Enabled = false;
                }
                else {
                    NodeContextMenu.Items[0].Enabled = true;
                }

                if (e.Node.Level > 1) {
                    for (int i = 1; i < NodeContextMenu.Items.Count; i++) {
                        NodeContextMenu.Items[i].Enabled = true;
                    }

                }
                else {
                    for (int i = 1; i < NodeContextMenu.Items.Count; i++) {
                        NodeContextMenu.Items[i].Enabled = false;
                    }
                }
                NodeContextMenu.Show(treeView, new Point(e.X, e.Y));

            }
        }

        private void UpdateTreeView() {
            var node = treeView.SelectedNode;
            if (node.Tag is RegistryKey) {
                var curKey = node.Tag as RegistryKey;
                node.Nodes.Clear();
                foreach (var key in curKey.GetSubKeyNames()) {
                    TreeNode treeNode = new TreeNode(key) { Tag = curKey.OpenSubKey(key, true) };
                    node.Nodes.Add(treeNode);
                }
            }
        }

        private void UpdateKeysView(TreeNode node) {
            keysView.Items.Clear();

            if (!(node.Tag is RegistryKey)) {
                return;
            }

            var regKey = node.Tag as RegistryKey;

            List<string> keys = regKey.GetValueNames().ToList();
            foreach (var valName in keys) {
                var type = regKey.GetValueKind(valName);
                string val = "";
                if (type == RegistryValueKind.Binary) {
                    foreach (var item in (byte[])regKey.GetValue(valName)) {
                        val += item.ToString();
                        val += " ";
                    }
                }
                else {
                    val = regKey.GetValue(valName).ToString();
                }
                string[] row = { valName, type.ToString(), val };
                Key key = new Key(valName, type, val);
                var listViewItem = new ListViewItem(row);
                keysView.Items.Add(listViewItem);
                keysView.Items[keysView.Items.Count - 1].Tag = key;
            }
        }

        private void addNodeItem_Click(object sender, EventArgs e) {
            using (AddNodeForm form = new AddNodeForm()) {
                var result = form.ShowDialog();
                if (result == DialogResult.OK) {
                    (treeView.SelectedNode.Tag as RegistryKey).CreateSubKey(form.nodeName);

                    UpdateTreeView();
                }
            }
        }

        private void renameNodeItem_Click(object sender, EventArgs e) {
            using (AddNodeForm form = new AddNodeForm()) {
                var result = form.ShowDialog();
                if (result == DialogResult.OK) {
                    var parent = treeView.SelectedNode.Parent.Tag as RegistryKey;
                    RegistryUtilities.RenameSubKey(parent, 
                        treeView.SelectedNode.Text,
                        form.nodeName);

                    var curNode = treeView.SelectedNode;

                    treeView.SelectedNode = treeView.SelectedNode.Parent;
                    UpdateTreeView();
                    treeView.SelectedNode = curNode;
                }
            }
            UpdateTreeView();
        }

        private void removeNodeItem_Click(object sender, EventArgs e) {
            (treeView.SelectedNode.Parent.Tag as RegistryKey).DeleteSubKeyTree(treeView.SelectedNode.Text);
            treeView.SelectedNode = treeView.SelectedNode.Parent;
            UpdateTreeView();
        }

        private void addKeyItem_Click(object sender, EventArgs e) {
            using (AddKeyForm form = new AddKeyForm()) {
                var result = form.ShowDialog();
                if (result == DialogResult.OK) {
                    Key key = form.Key;
                    var regKey = treeView.SelectedNode.Tag as RegistryKey;

                    regKey.SetValue(key.Name, key.Value, key.Type);
                    UpdateKeysView(treeView.SelectedNode);

                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e) {
            Key oldKey = keysView.FocusedItem.Tag as Key;
            using (AddKeyForm form = new AddKeyForm(oldKey)) {
                var result = form.ShowDialog();
                if (result == DialogResult.OK) {
                    Key newKey = form.Key;
                    (treeView.SelectedNode.Tag as RegistryKey).DeleteValue(oldKey.Name);
                    (treeView.SelectedNode.Tag as RegistryKey).SetValue(newKey.Name, newKey.Value, newKey.Type);
                    UpdateKeysView(treeView.SelectedNode);
                }
            }
        }

        private void keysView_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                if (keysView.FocusedItem != null) {
                    KeyContextMenu.Show(Cursor.Position);
                }
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e) {
            Key key = keysView.FocusedItem.Tag as Key;
            (treeView.SelectedNode.Tag as RegistryKey).DeleteValue(key.Name);
            UpdateKeysView(treeView.SelectedNode);
        }
    }
}
