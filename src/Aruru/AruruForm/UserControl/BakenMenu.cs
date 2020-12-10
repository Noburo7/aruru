using System;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using AruruDB;

namespace Aruru.AruruForm
{
    public partial class BakenMenu : UserControl
    {
        private IAruruDatabase _aruruDB;
        private static readonly string _dateDelimiter = "/";

        public BakenMenu()
        {
            InitializeComponent();
            var dbDir = Properties.Settings.Default.BakenDBDir;
            if (string.IsNullOrEmpty(dbDir) || !Directory.Exists(dbDir))
            {
                dbDir = Directory.GetCurrentDirectory();
            }
            _aruruDB = new AruruDatabase(Path.Combine(dbDir, "AruruDB.sqlite"));
        }

        private void NewRegistButton_Click(object sender, EventArgs e)
        {
            using (var form = new BakenRegistForm(_aruruDB))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    UpdateBakenListView();
                }
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            InitBakenListView();
            UpdateBakenListView();
        }

        private void UpdateBakenListView()
        {
            BakenListView.BeginUpdate();
            BakenListView.Clear();
            SetBakenListViewColumns();
            SetBakenListViewData();
            BakenListView.EndUpdate();
        }

        private void InitBakenListView()
        {
            BakenListView.FullRowSelect = true;
            BakenListView.MultiSelect = false;
            BakenListView.GridLines = true;
            BakenListView.Scrollable = true;
            BakenListView.View = View.Details;
            BakenListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void SetBakenListViewColumns()
        {
            BakenListView.Columns.Add("日付");
            BakenListView.Columns.Add("会場");
            BakenListView.Columns.Add("R");
            BakenListView.Columns.Add("レース名");
            BakenListView.Columns.Add("クラス");
            BakenListView.Columns.Add("コ");
            BakenListView.Columns.Add("距離");
            BakenListView.Columns.Add("馬場");
            BakenListView.Columns.Add("ハ");
            BakenListView.Columns.Add("牝");
            BakenListView.Columns.Add("齢");
            BakenListView.Columns.Add("購入金額");
            BakenListView.Columns.Add("払戻金額");
            BakenListView.Columns.Add("収支金額");
        }

        private void SetBakenListViewData()
        {
            foreach (var record in _aruruDB.RaceTable.Records)
            {
                string[] row = new string[14];
                row[0] = ConvertDateToDisplayDate(record.Date);
                row[1] = _aruruDB.TrackTable.Records.Where(o => o.ID == record.TrackID).First().Name;
                row[2] = record.RaceNumber.ToString();
                row[3] = record.RaceName;
                row[4] = _aruruDB.RaceClassTable.Records.Where(o => o.ID == record.RaceClassID).First().Name;
                row[5] = _aruruDB.TrackTypeTable.Records.Where(o => o.ID == record.TrackTypeID).First().Name;
                row[6] = record.Distance.ToString();
                row[7] = _aruruDB.TrackConditionTable.Records.Where(o => o.ID == record.TrackConditionID).First().Name;
                row[8] = record.IsHandicap == 1 ? "○" : "";
                row[9] = record.IsOnlyFemale == 1 ? "○" : "";
                row[10] = record.IsOnlyYouth == 1 ? "○" : "";

                var sum_invesment = _aruruDB.BakenTable.Records.Where(o => o.RaceID == record.ID).Sum(o => o.Investment);
                var sum_payout = _aruruDB.BakenTable.Records.Where(o => o.RaceID == record.ID).Sum(o => o.Payout);
                row[11] = sum_invesment.ToString("#,0");
                row[12] = sum_payout.ToString("#,0");
                row[13] = (sum_payout - sum_invesment).ToString("#,0");
                BakenListView.Items.Add(new ListViewItem(row));
                BakenListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private void BakenListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowBakenInfoForm();
        }

        private void ShowBakenInfoForm()
        {
            using (var bakenInfoForm = new BakenInfoForm(_aruruDB, SelectedItemRaceID()))
            {
                bakenInfoForm.ShowDialog();
            }
        }

        private int SelectedItemRaceID()
        {
            var trackNm = BakenListView.SelectedItems[0].SubItems[1].Text;
            var date = ConvertDisplayDateToDate(BakenListView.SelectedItems[0].SubItems[0].Text);
            var raceNumber = BakenListView.SelectedItems[0].SubItems[2].Text;
            return _aruruDB.GetRaceID(date, trackNm, int.Parse(raceNumber));
        }

        private string ConvertDateToDisplayDate(string date)
        {
            return date.Substring(0, 4) + _dateDelimiter + date.Substring(4, 2) + _dateDelimiter + date.Substring(6, 2);
        }

        private string ConvertDisplayDateToDate(string displayDate)
        {
            return displayDate.Replace(_dateDelimiter, "");
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (BakenListView.SelectedItems.Count == 0) return;
            var trackNm = BakenListView.SelectedItems[0].SubItems[1].Text;
            var date = BakenListView.SelectedItems[0].SubItems[0].Text;
            var raceNumber = BakenListView.SelectedItems[0].SubItems[2].Text;
            if (!ConfirmUserToDelete(date, trackNm, raceNumber)) return;
            date = ConvertDisplayDateToDate(date);
            _aruruDB.DeleteRaceBakenRecord(date, trackNm, int.Parse(raceNumber));
            MessageBox.Show("データを削除しました。", "データ削除", MessageBoxButtons.OK, MessageBoxIcon.Information);
            UpdateBakenListView();
        }

        private bool ConfirmUserToDelete(string date, string trackNm, string raceNumber)
        {
            var msg = "データを削除します。" + Environment.NewLine + Environment.NewLine;
            msg += $"{date} {trackNm}{raceNumber}R";
            var result = MessageBox.Show(msg, "データ削除", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            return result == DialogResult.OK;
        }
    }
}
