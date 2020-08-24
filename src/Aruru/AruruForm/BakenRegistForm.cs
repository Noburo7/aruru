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
        public Baken Baken { get; private set; }

        public BakenRegistForm(IDBController controller, Baken bukenInfo = null)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            _DBController = controller;
            Baken = bukenInfo;
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
            foreach (var record in _DBController.TrackTable)
            {
                TrackNameComboBox.Items.Add(record.Name);
            }
            TrackNameComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
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
            foreach (var record in _DBController.TrackConditionTable)
            {
                TrackConditionComboBox.Items.Add(record.Name);
            }
            TrackConditionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// TrackTypeComboBoxの初期化
        /// </summary>
        private void InitTrackTypeComboBox()
        {
            foreach (var record in _DBController.TrackTypeTable)
            {
                TrackTypeComboBox.Items.Add(record.Name);
            }
            TrackTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// RaceClassComboBoxの初期化
        /// </summary>
        private void InitRaceClassComboBox()
        {
            foreach (var record in _DBController.ClassTable)
            {
                RaceClassComboBox.Items.Add(record.Name);
            }
            RaceClassComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// BakenTypeComboBoxの初期化
        /// </summary>
        private void InitBakenTypeComboBox()
        {
            foreach (var record in _DBController.BakenTypeTable)
            {
                BakenTypeComboBox1.Items.Add(record.Name);
                BakenTypeComboBox2.Items.Add(record.Name);
                BakenTypeComboBox3.Items.Add(record.Name);
                BakenTypeComboBox4.Items.Add(record.Name);
                BakenTypeComboBox5.Items.Add(record.Name);
            }

            BakenTypeComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            BakenTypeComboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            BakenTypeComboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            BakenTypeComboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            BakenTypeComboBox5.DropDownStyle = ComboBoxStyle.DropDownList;
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
            DistanceComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void MoneyTextBoxChanged(object sender, EventArgs e)
        {
            UpdateStripStatusLabel();
        }

        private void UpdateStripStatusLabel()
        {
            var betSum = CalculateTotalBet();
            var payoutSum = CalculateTotalPayout();
            StripStatusLabel.Text = $"購入金額：{betSum}円    払戻金額：{payoutSum}円    レース収支：{payoutSum - betSum}円";
        }

        private int CalculateTotalBet()
        {
            int.TryParse(BetTextBox1.Text, out var bet1);
            int.TryParse(BetTextBox2.Text, out var bet2);
            int.TryParse(BetTextBox3.Text, out var bet3);
            int.TryParse(BetTextBox4.Text, out var bet4);
            int.TryParse(BetTextBox5.Text, out var bet5);
            return (bet1 + bet2 + bet3 + bet4 + bet5) * 100;
        }

        private int CalculateTotalPayout()
        {
            int.TryParse(PayoutTextBox1.Text, out var payout1);
            int.TryParse(PayoutTextBox2.Text, out var payout2);
            int.TryParse(PayoutTextBox3.Text, out var payout3);
            int.TryParse(PayoutTextBox4.Text, out var payout4);
            int.TryParse(PayoutTextBox5.Text, out var payout5);
            return payout1 + payout2 + payout3 + payout4 + payout5;
        }

        private void RegistButton_Click(object sender, EventArgs e)
        {            
            if (!ValidateUserInput(out var errMsg))
            {
                MessageBox.Show(errMsg, "馬券登録", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Close();
        }

        private bool ValidateUserInput(out string errMsg)
        {
            //競馬場名
            if (TrackNameComboBox.SelectedIndex == -1)
            {
                errMsg = "競馬場名を選択してください。";
                return false;
            }

            //レース番号
            if (RaceNumberComboBox.SelectedIndex == -1)
            {
                errMsg = "レース番号を選択してください。";
                return false;
            }

            //クラス
            if (RaceClassComboBox.SelectedIndex == -1)
            {
                errMsg = "レースクラスを選択してください。";
                return false;
            }

            //コースタイプ
            if (TrackTypeComboBox.SelectedIndex == -1)
            {
                errMsg = "コースタイプ(芝/ダ)を選択してください。";
                return false;
            }

            //距離
            if (DistanceComboBox.SelectedItem.ToString() == null)
            {
                errMsg = "距離を選択してください。";
                return false;
            }

            errMsg = null;
            return true;
        }
    }
}
