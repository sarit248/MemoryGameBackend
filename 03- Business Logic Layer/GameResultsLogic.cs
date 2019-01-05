using System;
using System.Collections.Generic;
using System.Linq;

namespace Match_Memory_Game
{
    public class GameResultsLogic : BaseLogic
    {
        public List<GameResultModel> GetAllResults()
        {
            return DB.GameResults.Select(g => new GameResultModel

            {
                gameResultID = g.GameResultID,
                userID = g.UserID,
                userFullName = g.User.FullName,
                userName = g.User.UserName,
                stepsTaken = g.StepsTaken,
                datePlayed = g.DatePlayed,
                gameSessionLength = g.GameSessionLength.Hours * 60 * 60 + (g.GameSessionLength.Minutes * 60) + g.GameSessionLength.Seconds + (long)g.GameSessionLength.Milliseconds / 60,
            }).ToList();
        }

        public GameResultModel GetOneGameResult(int id)
        {
            return DB.GameResults
                .Where(g => g.GameResultID == id)
                .Select(g => new GameResultModel
                {
                    gameResultID = g.GameResultID,
                    userID = g.UserID,
                    userFullName = g.User.FullName,
                    userName = g.User.UserName,
                    stepsTaken = g.StepsTaken,
                    datePlayed = g.DatePlayed,
                    gameSessionLength = g.GameSessionLength.Milliseconds,
                }).SingleOrDefault();
        }



        public GameResultModel AddGameResult(GameResultModel gameResultModel)
        {
            GameResult gameResult = new GameResult
            {
                UserID = gameResultModel.userID,
                StepsTaken = gameResultModel.stepsTaken,
                DatePlayed = gameResultModel.datePlayed,
                GameSessionLength = TimeSpan.FromMilliseconds(gameResultModel.gameSessionLength),
            };
            GameResult result = DB.GameResults.Add(gameResult);
            DB.SaveChanges();

            return GetOneGameResult(result.GameResultID);
        }
    }
}
