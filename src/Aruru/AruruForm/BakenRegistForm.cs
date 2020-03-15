using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Aruru.AruruForm
{
    public partial class BakenRegistForm : Form
    {
        public Baken Baken { get; set; }


        public BakenRegistForm() {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            InitCourseList();
            UpdateStripStatusLabel();
        }

        private void InitCourseList() {
        }

        private void Form_Load(object sender, EventArgs e) {
            InitCourseNameComboBox();
            InitRaceNumberComboBox();
            InitCourseConditionComboBox();
            InitCourseTypeComboBox();
            InitRaceClassComboBox();
            InitBakenTypeComboBox();
        }

        private void InitCourseNameComboBox() {
        }

        private void InitRaceNumberComboBox() {
            for (var i = 1; i <= 12; i++) {
                RaceNumberComboBox.Items.Add(i);
            }
            RaceNumberComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void InitCourseConditionComboBox() {
            ConditionComboBox.Items.Add("良");
            ConditionComboBox.Items.Add("稍重");
            ConditionComboBox.Items.Add("重");
            ConditionComboBox.Items.Add("不良");
        }

        private void InitCourseTypeComboBox() {
            CourseTypeComboBox.Items.Add("芝");
            CourseTypeComboBox.Items.Add("ダ");
        }

        private void InitRaceClassComboBox() {
            RaceClassComboBox.Items.Add("新馬");
            RaceClassComboBox.Items.Add("未勝利");
            RaceClassComboBox.Items.Add("1勝クラス");
            RaceClassComboBox.Items.Add("2勝クラス");
            RaceClassComboBox.Items.Add("3勝クラス");
            RaceClassComboBox.Items.Add("オープン");
            RaceClassComboBox.Items.Add("リステッド");
            RaceClassComboBox.Items.Add("G3");
            RaceClassComboBox.Items.Add("G2");
            RaceClassComboBox.Items.Add("GI");
        }

        private void InitBakenTypeComboBox() {
            var BakenTypeComboBoxList = new List<ComboBox>();
            BakenTypeComboBoxList.Add(BakenTypeComboBox1);
            BakenTypeComboBoxList.Add(BakenTypeComboBox2);
            BakenTypeComboBoxList.Add(BakenTypeComboBox3);
            BakenTypeComboBoxList.Add(BakenTypeComboBox4);
            BakenTypeComboBoxList.Add(BakenTypeComboBox5);

            foreach (var comboBox in BakenTypeComboBoxList) {
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox.Items.Add("単勝");
                comboBox.Items.Add("複勝");
                comboBox.Items.Add("枠連");
                comboBox.Items.Add("馬連");
                comboBox.Items.Add("馬単");
                comboBox.Items.Add("ワイド");
                comboBox.Items.Add("3連複");
                comboBox.Items.Add("3連単");
            }
        }

        private void ClearButton1_Click(object sender, EventArgs e) {
            BakenTypeComboBox1.SelectedIndex = -1;
            BetTextBox1.Clear();
            PayoutTextBox1.Clear();
        }

        private void ClearButton2_Click(object sender, EventArgs e) {
            BakenTypeComboBox2.SelectedIndex = -1;
            BetTextBox2.Clear();
            PayoutTextBox2.Clear();
        }

        private void ClearButton3_Click(object sender, EventArgs e) {
            BakenTypeComboBox3.SelectedIndex = -1;
            BetTextBox3.Clear();
            PayoutTextBox3.Clear();
        }

        private void ClearButton4_Click(object sender, EventArgs e) {
            BakenTypeComboBox4.SelectedIndex = -1;
            BetTextBox4.Clear();
            PayoutTextBox4.Clear();
        }

        private void ClearButton5_Click(object sender, EventArgs e) {
            BakenTypeComboBox5.SelectedIndex = -1;
            BetTextBox5.Clear();
            PayoutTextBox5.Clear();
        }

        private void CourseNameComboBox_SelectIndexChanged(object sender, EventArgs e) {
            SetDistanceComboBox();
        }
        private void CourseTypeComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            SetDistanceComboBox();
        }

        private void SetDistanceComboBox() {
            DistanceComboBox.Items.Clear();
            /*
            foreach (var course in _CourseList) {
                if (course.Name != CourseNameComboBox.Text) continue;
                if (CourseTypeComboBox.Text == "芝") {
                    foreach (var distance in course.GrassCourse()) {
                        DistanceComboBox.Items.Add(distance);
                    }
                }
                else if (CourseTypeComboBox.Text == "ダ") {
                    foreach (var distance in course.DirtCourse()) {
                        DistanceComboBox.Items.Add(distance);
                    }
                }
            }
            */
        }

        private void MoneyTextBoxChanged(object sender, EventArgs e) {
            UpdateStripStatusLabel();
        }

        private void UpdateStripStatusLabel() {
            var betSum = CalculateTotalBet();
            var payoutSum = CalculateTotalPayout();
            StripStatusLabel.Text = $"購入金額：{betSum}円    払戻金額：{payoutSum}円    レース収支：{payoutSum - betSum}円";
        }

        private int CalculateTotalBet() {
            int.TryParse(BetTextBox1.Text, out var bet1);
            int.TryParse(BetTextBox2.Text, out var bet2);
            int.TryParse(BetTextBox3.Text, out var bet3);
            int.TryParse(BetTextBox4.Text, out var bet4);
            int.TryParse(BetTextBox5.Text, out var bet5);
            return (bet1 + bet2 + bet3 + bet4 + bet5) * 100;
        }

        private int CalculateTotalPayout() {
            int.TryParse(PayoutTextBox1.Text, out var payout1);
            int.TryParse(PayoutTextBox2.Text, out var payout2);
            int.TryParse(PayoutTextBox3.Text, out var payout3);
            int.TryParse(PayoutTextBox4.Text, out var payout4);
            int.TryParse(PayoutTextBox5.Text, out var payout5);
            return payout1 + payout2 + payout3 + payout4 + payout5;
        }

        private void RegistButton_Click(object sender, EventArgs e) {
            Close();
        }

        private void SetBakenResult() {
            /*
            Baken.Results.Clear();
            if (BakenTypeComboBox1.SelectedIndex != -1) {
                Baken.Results.Add(new BakenResult(BakenTypeComboBox1.Text, int.Parse(BetTextBox1.Text) * 100, int.Parse(PayoutTextBox1.Text)));
            }

            if (BakenTypeComboBox2.SelectedIndex != -1) {
                Baken.Results.Add(new BakenResult(BakenTypeComboBox2.Text, int.Parse(BetTextBox2.Text) * 100, int.Parse(PayoutTextBox2.Text)));
            }

            if (BakenTypeComboBox3.SelectedIndex != -1) {
                Baken.Results.Add(new BakenResult(BakenTypeComboBox3.Text, int.Parse(BetTextBox3.Text) * 100, int.Parse(PayoutTextBox3.Text)));
            }

            if (BakenTypeComboBox4.SelectedIndex != -1) {
                Baken.Results.Add(new BakenResult(BakenTypeComboBox4.Text, int.Parse(BetTextBox4.Text) * 100, int.Parse(PayoutTextBox4.Text)));
            }

            if (BakenTypeComboBox5.SelectedIndex != -1) {
                Baken.Results.Add(new BakenResult(BakenTypeComboBox5.Text, int.Parse(BetTextBox5.Text) * 100, int.Parse(PayoutTextBox5.Text)));
            }
            */
        }
    }
}
