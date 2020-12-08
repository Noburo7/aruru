using System;
using System.Windows.Forms;

namespace Aruru.AruruForm
{
    public partial class MenuForm : Form
    {
        private static readonly Control welcome = new Welcome();
        private static readonly Control bakenMenu = new BakenMenu();
        private static readonly Control horseAnalyze = new HorseAnalyze();
        private static readonly Control lapAnalyze = new LapAnalyze();
        private static readonly Control config = new Config();

        public MenuForm() {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            MainPanel.Controls.Add(welcome);
            MainPanel.Controls.Add(bakenMenu);
            MainPanel.Controls.Add(horseAnalyze);
            MainPanel.Controls.Add(lapAnalyze);
            MainPanel.Controls.Add(config);

            welcome.Visible = true;
            bakenMenu.Visible = false;
            horseAnalyze.Visible = false;
            lapAnalyze.Visible = false;
            config.Visible = false;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BakenMenuButton_Click(object sender, EventArgs e)
        {
            welcome.Visible = false;
            bakenMenu.Visible = true;
            horseAnalyze.Visible = false;
            lapAnalyze.Visible = false;
            config.Visible = false;
        }

        private void SettingButton_Click(object sender, EventArgs e)
        {
            welcome.Visible = false;
            bakenMenu.Visible = false;
            horseAnalyze.Visible = false;
            lapAnalyze.Visible = false;
            config.Visible = true;
        }

        private void LapAnalysisButton_Click(object sender, EventArgs e)
        {
            welcome.Visible = false;
            bakenMenu.Visible = false;
            horseAnalyze.Visible = false;
            lapAnalyze.Visible = true;
            config.Visible = false;
        }

        private void HorseAnalyzeButton_Click(object sender, EventArgs e)
        {
            welcome.Visible = false;
            bakenMenu.Visible = false;
            horseAnalyze.Visible = true;
            lapAnalyze.Visible = false;
            config.Visible = false;
        }
    }
}
