using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AruruDB;

namespace Aruru.AruruForm
{
    /// <summary>
    /// 馬券登録・編集画面
    /// </summary>
    public partial class BakenRegistForm : Form
    {
        private IAruruDatabase _DB;
        private ComboBox[] _bakenTypeComboBoxArray;
        private TextBox[] _betTextBoxArray;
        private TextBox[] _payoutTextBoxArray;
        private Button[] _clearButtonArray;

        public BakenRegistForm(IAruruDatabase database)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            _DB = database;

            _bakenTypeComboBoxArray = new ComboBox[5]
            {
                BakenTypeComboBox1,
                BakenTypeComboBox2,
                BakenTypeComboBox3,
                BakenTypeComboBox4,
                BakenTypeComboBox5
            };

            _betTextBoxArray = new TextBox[5]
            {
                BetTextBox1,
                BetTextBox2,
                BetTextBox3,
                BetTextBox4,
                BetTextBox5
            };

            _payoutTextBoxArray = new TextBox[5]
            {
                PayoutTextBox1,
                PayoutTextBox2,
                PayoutTextBox3,
                PayoutTextBox4,
                PayoutTextBox5
            };

            _clearButtonArray = new Button[5]
            {
                ClearButton1,
                ClearButton2,
                ClearButton3,
                ClearButton4,
                ClearButton5
            };
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
            foreach (var record in _DB.TrackTable.Records)
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
            foreach (var record in _DB.TrackConditionTable.Records)
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
            foreach (var record in _DB.TrackTypeTable.Records)
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
            foreach (var record in _DB.RaceClassTable.Records)
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
            foreach (var bakenTypeComboBox in _bakenTypeComboBoxArray)
            {
                foreach (var record in _DB.BakenTypeTable.Records)
                {
                    bakenTypeComboBox.Items.Add(record.Name);
                }
                bakenTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
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
            var distanceList = _DB.DistanceList(TrackNameComboBox.Text, TrackTypeComboBox.Text);
            foreach (var distance in distanceList)
            {
                DistanceComboBox.Items.Add(distance);
            }

            if (TrackNameComboBox.Text != "地方" && TrackNameComboBox.Text != "海外")
            {
                DistanceComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            }
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

            //レース情報と馬券をDBに登録
            try
            {
                _DB.InsertBakenResult(GenerateRaceInfo(), GenerateBakenList(), RemarkTextBox.Text);
                MessageBox.Show("登録完了！", "馬券登録", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "馬券登録", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
            if (string.IsNullOrEmpty(DistanceComboBox.Text))
            {
                errMsg = "距離を選択してください。";
                return false;
            }

            errMsg = null;
            return true;
        }

        private IRace GenerateRaceInfo()
        {
            var raceInfo = new Race();
            raceInfo.Date = DateTimePicker.Value.ToString("yyyyMMdd");
            raceInfo.TrackNm = TrackNameComboBox.Text;
            raceInfo.RaceNum = int.Parse(RaceNumberComboBox.Text);
            raceInfo.RaceNm = RaceNameTextBox.Text;
            raceInfo.TrackTypeNm = TrackTypeComboBox.Text;
            raceInfo.Distance = int.Parse(DistanceComboBox.Text);
            raceInfo.RaceClassNm = RaceClassComboBox.Text;
            raceInfo.TrackConditionNm = TrackConditionComboBox.Text;
            raceInfo.IsHandicap = HandicapCheckBox.Checked;
            raceInfo.IsOnlyFemale = FemaleCheckBox.Checked;
            raceInfo.IsOnlyYouth = AgeCheckBox.Checked;
            return raceInfo;
        }

        private List<IBaken> GenerateBakenList()
        {
            var bakenList = new List<IBaken>();
            if (BakenTypeComboBox1.SelectedIndex != -1)
            {
                var baken = new Baken();
                baken.BakenTypeNm = BakenTypeComboBox1.Text;
                baken.Investment = int.Parse(BetTextBox1.Text) * 100;
                baken.Payout = int.Parse(PayoutTextBox1.Text);
                bakenList.Add(baken);
            }

            if (BakenTypeComboBox2.SelectedIndex != -1)
            {
                var baken = new Baken();
                baken.BakenTypeNm = BakenTypeComboBox2.Text;
                baken.Investment = int.Parse(BetTextBox2.Text) * 100;
                baken.Payout = int.Parse(PayoutTextBox2.Text);
                bakenList.Add(baken);
            }

            if (BakenTypeComboBox3.SelectedIndex != -1)
            {
                var baken = new Baken();
                baken.BakenTypeNm = BakenTypeComboBox3.Text;
                baken.Investment = int.Parse(BetTextBox3.Text) * 100;
                baken.Payout = int.Parse(PayoutTextBox3.Text);
                bakenList.Add(baken);
            }

            if (BakenTypeComboBox4.SelectedIndex != -1)
            {
                var baken = new Baken();
                baken.BakenTypeNm = BakenTypeComboBox4.Text;
                baken.Investment = int.Parse(BetTextBox4.Text) * 100;
                baken.Payout = int.Parse(PayoutTextBox4.Text);
                bakenList.Add(baken);
            }

            if (BakenTypeComboBox5.SelectedIndex != -1)
            {
                var baken = new Baken();
                baken.BakenTypeNm = BakenTypeComboBox5.Text;
                baken.Investment = int.Parse(BetTextBox5.Text) * 100;
                baken.Payout = int.Parse(PayoutTextBox5.Text);
                bakenList.Add(baken);
            }
            return bakenList;
        }
    }
}
