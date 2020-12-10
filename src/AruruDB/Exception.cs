using System;

namespace AruruDB
{
    public class RaceDuplicationException : Exception
    {
        public RaceDuplicationException() : base("既に登録されているレースです。")
        {
            //DoNothing.
        }
    }
}
