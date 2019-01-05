using System;

namespace Match_Memory_Game
{
    public class GameResultModel
    {
        public int gameResultID { get; set; }
        public int userID { get; set; }
        public string userFullName { get; set; }
        public string userName { get; set; }
        public int stepsTaken { get; set; }
        public DateTime datePlayed { get; set; }
        public long gameSessionLength { get; set; }
    }
}
