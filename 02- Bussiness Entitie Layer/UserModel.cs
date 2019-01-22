using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace Match_Memory_Game
{
    public class UserModel
    {

        public UserModel()
        {
            email = null;
        }



        public bool IsValid(string email)
        {
            try
            {
                MailAddress mail = new MailAddress(email);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }





        public int userID { get; set; }

        [Required(ErrorMessage = "Name and last name are required")]
        public string fullName { get; set; }

        [Required(ErrorMessage = "UserName is required")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string password { get; set; }

        [GameRegularExpression(@"^[\w.]+@[\w.]+\.[.a-zA-Z]+$")]
        public string email { get; set; }


        public Nullable<DateTime> dateOfBirth { get; set; }

    }
}

