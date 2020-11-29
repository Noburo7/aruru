using System;
using System.Windows.Forms;
using System.Linq;
using AruruDB;

namespace Aruru.AruruForm
{
    /// <summary>
    /// 馬券メニュー画面
    /// </summary>
    public partial class BakenMenuForm : Form
    {
        private IAruruDatabase _aruruDB = new AruruDatabase("AruruDB.sqlite");

        public BakenMenuForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
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
                row[0] = record.Date;
                row[1] = _aruruDB.TrackTable.Records.Where(o => o.ID == record.TrackID).First().Name;
                row[2] = record.RaceNumber.ToString();
                row[3] = record.RaceName;
                row[4] = _aruruDB.RaceClassTable.Records.Where(o => o.ID == record.RaceClassID).First().Name;
                row[5] = _aruruDB.TrackTypeTable.Records.Where(o => o.ID == record.TrackTypeID).First().Name;
                row[6] = record.Distance.ToString();
                row[7] = _aruruDB.TrackConditionTable.Records.Where(o => o.ID == record.TrackConditionID).First().Name;
                row[8] = record.IsHandicap == 1 ? "○" : "";
                row[9] = record.IsOnlyFemale == 1 ? "○" : "";
                row[10] = record.IsOnlyYouth == 1? "○" : "";
                row[11] = _aruruDB.BakenTable.Records.Where(o => o.RaceID == record.ID).Sum(o => o.Investment).ToString("#,0");
                row[12] = _aruruDB.BakenTable.Records.Where(o => o.RaceID == record.ID).Sum(o => o.Payout).ToString("#,0");
                row[13] = (int.Parse(row[12]) - int.Parse(row[11])).ToString("#,0");
                BakenListView.Items.Add(new ListViewItem(row));
                BakenListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }
    }
}
