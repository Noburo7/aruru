using System;
using System.Windows.Forms;

namespace Aruru.AruruForm
{
    public partial class MenuForm : Form
    {
        public MenuForm() {
            InitializeComponent();
            InitUI();
        }

        private void InitUI() {
            this.Text = Properties.Resources.Menu_WindowTitle;
            BakenRegistButton.Text = Properties.Resources.Menu_Button_BakenRegist;
            CloseButton.Text = Properties.Resources.Menu_Button_Close;
            DirectionLabel.Text = Properties.Resources.Menu_Label_Direction;
        }

        private void CloseButton_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
