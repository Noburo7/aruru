using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using AruruDB;
using AruruDB.Table.Record;

namespace Aruru.AruruForm
{
    public partial class BakenInfoForm : Form
    {
        private IAruruDatabase _db;
        private int _raceID;

        public BakenInfoForm(IAruruDatabase database, int raceID)
        {
            InitializeComponent();
            _db = database;
            _raceID = raceID;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            BakenInfoTextBox.ReadOnly = true;

            var remark = _db.RemarkTable.GetRemark(_raceID);
            var bakenInfo = _db.BakenTable.GetBakenList(_raceID);
            var raceInfo = _db.RaceTable.GetRaceRecord(_raceID);
            InitListBox(raceInfo, bakenInfo, remark);
        }

        private void InitListBox(IRaceRecord raceInfo, IEnumerable<IBakenRecord>bakenInfo, string remark)
        {
            var text = "◆レース情報" + Environment.NewLine;
            var courseInfo = _db.CourseTable.GetCourseInfo(raceInfo.CourseID);
            var trackNm = _db.TrackTable.Records.Where(o => o.ID == courseInfo.TrackID).First().Name;
            var trackType = _db.TrackTypeTable.Records.Where(o => o.ID == courseInfo.TrackTypeID).First().Name;
            var classNm = _db.RaceClassTable.Records.Where(o => o.ID == raceInfo.RaceClassID).First().Name;

            text += raceInfo.Date.Substring(0, 4) + "/" + raceInfo.Date.Substring(4, 2) + "/" + raceInfo.Date.Substring(6, 2);
            text += $" {trackNm}{raceInfo.RaceNumber}R {raceInfo.RaceName} {classNm}";
            text += $" {trackType}{courseInfo.Distance}m" + Environment.NewLine;

            if (raceInfo.IsOnlyYouth == 1)
            {
                text += " 馬齢";
            }

            if (raceInfo.IsOnlyFemale == 1)
            {
                text += " 牝馬";
            }

            if (raceInfo.IsHandicap == 1)
            {
                text += " ハンデ";
            }

            text += Environment.NewLine + Environment.NewLine;
            text += "◆馬券" + Environment.NewLine;
            foreach (var baken in bakenInfo)
            {
                text += _db.BakenTypeTable.BakenType(baken.BakenTypeID);
                text += baken.Investment + "円 → " + baken.Payout + "円";
                if (baken.Payout > 0)
                {
                    text += " 収支:" + (baken.Payout - baken.Investment) + "円";
                    text += Environment.NewLine;
                }
            }

            if (bakenInfo.Count() > 1)
            {
                text += Environment.NewLine;
                text += "合計購入額： " + bakenInfo.Sum(o => o.Investment) + "円" + Environment.NewLine;
                text += "合計払戻額： " + bakenInfo.Sum(o => o.Payout) + "円" + Environment.NewLine;
                text += "合計収支　： " + (bakenInfo.Sum(o => o.Payout) - bakenInfo.Sum(o => o.Investment)) + "円";
                text += Environment.NewLine;
            }

            text += Environment.NewLine;
            text += "◆備考" + Environment.NewLine;
            text += remark;

            BakenInfoTextBox.Text = text;
            BakenInfoTextBox.SelectionStart = 0;
        }
    }
}
