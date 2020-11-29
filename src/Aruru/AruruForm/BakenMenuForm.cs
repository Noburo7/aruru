using System;
using System.Windows.Forms;
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

        private void Form_Load(object sender, EventArgs e) {
            InitBakenListView();
            UpdateBakenListView();
        }

        private void UpdateBakenListView() {
            BakenListView.BeginUpdate();
            BakenListView.Clear();
            SetBakenListViewColumns();
            SetBakenListViewData();
            BakenListView.EndUpdate();
        }

        private void InitBakenListView() {
            BakenListView.FullRowSelect = true;
            BakenListView.MultiSelect = false;
            BakenListView.GridLines = true;
            BakenListView.Scrollable = true;
            BakenListView.View = View.Details;
            BakenListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void SetBakenListViewColumns() {
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
            //_database.LoadAruruDB();
            //var bakenList = _database.GenerateBakenList();
            //foreach (var item in bakenList) {
            //    string[] row = new string[14];
            //    row[0] = item.Date.ToString("yyyy/MM/dd");
            //    row[1] = item.TrackName;
            //    row[2] = item.RaceNum.ToString();
            //    row[3] = item.RaceName;
            //    row[4] = item.Class;
            //    row[5] = item.TrackType;
            //    row[6] = item.Distance.ToString();
            //    row[7] = item.TrackCondition;
            //    row[8] = item.IsHandicap ? "○" : "";
            //    row[9] = item.IsOnlyFemale ? "○" : "";
            //    row[10] = item.IsOnlyYouth ? "○" : "";
            //    row[11] = item.Bettings.Sum(o => o.Investment).ToString("#,0");
            //    row[12] = item.Bettings.Sum(o => o.Payout).ToString("#,0");
            //    row[13] = (int.Parse(row[12]) - int.Parse(row[11])).ToString("#,0"); 
            //    BakenListView.Items.Add(new ListViewItem(row));
            //    BakenListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            //}
        }
    }
}
