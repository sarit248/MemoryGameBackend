using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Match_Memory_Game
{
    public class UsersFeedbackLogic : BaseLogic
    {

        public UserFeedbackModel GetOneFeedback(int feedbackID)
        {
            return DB.UsersFeedbacks
                .Where(u => u.FeedbackID == feedbackID)
                .Select(u => new UserFeedbackModel
                {
                    feedbackID = u.FeedbackID,
                    feedbackDate = u.FeedbackDate,
                    feedbackText = u.FeedbackText,
                    userFullName = u.User.FullName,
                    userID = u.UserID
                }).SingleOrDefault();
        }

        public UserFeedbackModel AddFeedback(UserFeedbackModel userFeedbackModel)
        {
            UsersFeedback userFeedback = new UsersFeedback
            {
                UserID = userFeedbackModel.userID,
                FeedbackDate = userFeedbackModel.feedbackDate,
                FeedbackText = userFeedbackModel.feedbackText
            };
            DB.UsersFeedbacks.Add(userFeedback);
            DB.SaveChanges();

            userFeedbackModel.feedbackID = userFeedback.FeedbackID;
            return GetOneFeedback(userFeedback.FeedbackID);
        }


        public List<UserFeedbackModel> GetAllFeedbacks()
        {
            return DB.UsersFeedbacks.Select(u => new UserFeedbackModel
            {
                feedbackID = u.FeedbackID,
                feedbackDate = u.FeedbackDate,
                feedbackText = u.FeedbackText,
                userFullName = u.User.FullName,
                userID = u.UserID

            }).ToList();
        }
    }
}
