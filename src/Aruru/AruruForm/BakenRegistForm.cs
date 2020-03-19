using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Aruru.AruruForm
{
    /// <summary>
    /// 馬券登録・編集画面
    /// </summary>
    public partial class BakenRegistForm : Form
    {
        private IDBController _DBController;
        public Baken Baken { get; set; }

        public BakenRegistForm(IDBController controller)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            _DBController = controller;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            InitTrackNameComboBox();
            InitRaceNumberComboBox();
            InitTrackConditionComboBox();
            InitTrackTypeComboBox();
            InitRaceClassComboBox();
            InitBakenTypeComboBox();
            UpdateStripStatusLabel();
        }

        /// <summary>
        /// TrackNameComboBoxの初期化
        /// </summary>
        private void InitTrackNameComboBox()
        {
            foreach (var name in _DBController.EnumerateTrackNames())
            {
                TrackNameComboBox.Items.Add(name);
            }
        }

        /// <summary>
        /// RaceNumberComboBoxの初期化
        /// </summary>
        private void InitRaceNumberComboBox()
        {
            for (var i = 1; i <= 12; i++)
            {
                RaceNumberComboBox.Items.Add(i);
            }
            RaceNumberComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// TrackConditionComboBoxの初期化
        /// </summary>
        private void InitTrackConditionComboBox()
        {
            foreach (var name in _DBController.EnumerateTrackConditionNames())
            {
                TrackConditionComboBox.Items.Add(name);
            }
        }

        /// <summary>
        /// TrackTypeComboBoxの初期化
        /// </summary>
        private void InitTrackTypeComboBox()
        {
            foreach (var name in _DBController.EnumerateTrackTypeNames())
            {
                TrackTypeComboBox.Items.Add(name);
            }
        }

        /// <summary>
        /// RaceClassComboBoxの初期化
        /// </summary>
        private void InitRaceClassComboBox()
        {
            foreach (var name in _DBController.EnumerateClassNames())
            {
                RaceClassComboBox.Items.Add(name);
            }
        }

        /// <summary>
        /// BakenTypeComboBoxの初期化
        /// </summary>
        private void InitBakenTypeComboBox()
        {
            foreach (var name in _DBController.EnumerateBakenTypeNames())
            {
                BakenTypeComboBox1.Items.Add(name);
                BakenTypeComboBox2.Items.Add(name);
                BakenTypeComboBox3.Items.Add(name);
                BakenTypeComboBox4.Items.Add(name);
                BakenTypeComboBox5.Items.Add(name);
            }
        }

        private void ClearButton1_Click(object sender, EventArgs e)
        {
            BakenTypeComboBox1.SelectedIndex = -1;
            BetTextBox1.Clear();
            PayoutTextBox1.Clear();
        }

        private void ClearButton2_Click(object sender, EventArgs e)
        {
            BakenTypeComboBox2.SelectedIndex = -1;
            BetTextBox2.Clear();
            PayoutTextBox2.Clear();
        }

        private void ClearButton3_Click(object sender, EventArgs e)
        {
            BakenTypeComboBox3.SelectedIndex = -1;
            BetTextBox3.Clear();
            PayoutTextBox3.Clear();
        }

        private void ClearButton4_Click(object sender, EventArgs e)
        {
            BakenTypeComboBox4.SelectedIndex = -1;
            BetTextBox4.Clear();
            PayoutTextBox4.Clear();
        }

        private void ClearButton5_Click(object sender, EventArgs e)
        {
            BakenTypeComboBox5.SelectedIndex = -1;
            BetTextBox5.Clear();
            PayoutTextBox5.Clear();
        }

        private void CourseNameComboBox_SelectIndexChanged(object sender, EventArgs e)
        {
            SetDistanceComboBox();
        }

        private void CourseTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDistanceComboBox();
        }

        private void SetDistanceComboBox()
        {
            DistanceComboBox.Items.Clear();
            if (string.IsNullOrEmpty(TrackNameComboBox.Text) || string.IsNullOrEmpty(TrackTypeComboBox.Text)) return;
            var distanceList = _DBController.EnumerateDistance(TrackNameComboBox.Text, TrackTypeComboBox.Text);
            foreach (var distance in distanceList)
            {
                DistanceComboBox.Items.Add(distance);
            }
        }

        private void MoneyTextBoxChanged(object sender, EventArgs e)
        {
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
