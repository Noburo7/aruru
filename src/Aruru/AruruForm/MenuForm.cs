using System;
using System.Windows.Forms;

namespace Aruru.AruruForm
{
    public partial class MenuForm : Form
    {
        public MenuForm() {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
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
            using (var form = new ConfigForm())
            {
                form.ShowDialog();
            }
        }

        private void SplitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
