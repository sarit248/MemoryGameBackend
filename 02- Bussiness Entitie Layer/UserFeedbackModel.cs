using System;
using System.ComponentModel.DataAnnotations;

namespace Match_Memory_Game
{
    public class UserFeedbackModel
    {
        public int userID { get; set; }

        public string userFullName { get; set; }

        public int feedbackID { get; set; }

        [MinLength(2, ErrorMessage = "Min length must be 2 chars.")]
        public string feedbackText { get; set; }

        public DateTime feedbackDate { get; set; }

    }
}
