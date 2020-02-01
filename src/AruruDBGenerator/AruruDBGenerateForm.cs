using System;
using System.Windows.Forms;

namespace AruruDB
{
    public partial class AruruDBGenerateForm : Form
    {
        public AruruDBGenerateForm() {
            InitializeComponent();
        }

        private void CreateTablesButton_Click(object sender, EventArgs e) {
            var dbFileNm = DBFileNameTextBox.Text + ".sqlite";
            new AruruDBGenerator(dbFileNm, new Progress(ProgressListBox)).Run();
        }

        private void Form_Load(object sender, EventArgs e) {
            DBFileNameTextBox.Text = "AruruDB";
        }
    }
}
