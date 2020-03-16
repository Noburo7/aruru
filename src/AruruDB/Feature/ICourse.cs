﻿namespace AruruDB
{
    /// <summary>
    /// コース
    /// </summary>
    public interface ICourse
    {
        /// <summary>
        /// コースID
        /// </summary>
        int ID { get; }

        /// <summary>
        /// 競馬場名
        /// </summary>
        int TrackID { get; }

        /// <summary>
        /// 芝・ダ
        /// </summary>
        int TrackTypeID { get; }

        /// <summary>
        /// 距離
        /// </summary>
        int Distance { get; }
    }
}
