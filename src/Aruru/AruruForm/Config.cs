using System;
using System.Windows.Forms;

namespace Aruru.AruruForm
{
    public partial class Config : UserControl
    {
        public Config()
        {
            InitializeComponent();
            BakenDBDirTextBox.Text = Properties.Settings.Default.BakenDBDir;
            if (string.IsNullOrEmpty(BakenDBDirTextBox.Text))
            {
                BakenDBDirTextBox.Text = Application.ExecutablePath;
            }
        }

        private void BakenDBDirBrowseButton_Click(object sender, EventArgs e)
        {
            var dir = Properties.Settings.Default.BakenDBDir;
            if (dir == string.Empty)
            {
                dir = @"C:\";
            }
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = "フォルダを指定してください。";
                dlg.RootFolder = Environment.SpecialFolder.Desktop;
                dlg.SelectedPath = dir;
                dlg.ShowNewFolderButton = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.BakenDBDir = dlg.SelectedPath;
                    Properties.Settings.Default.Save();
                    BakenDBDirTextBox.Text = dlg.SelectedPath;
                }
            }
        }
    }
}
