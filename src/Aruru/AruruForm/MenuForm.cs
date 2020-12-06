using System;
using System.Windows.Forms;

namespace Aruru.AruruForm
{
    public partial class MenuForm : Form
    {
        public MenuForm() {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            MainPanel.Controls.Add(new Welcome());
        }

        private void CloseButton_Click(object sender, EventArgs e) {
            Close();
        }

        private void BakenMenuButton_Click(object sender, EventArgs e) {
            var form = new BakenMenuForm();
            form.Show();
        }

        private void SettingButton_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(new Config());
        }
    }
}
