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

        //[GameRegularExpression(@"^[a-zA-Z]{4,}(?: [a-zA-Z]+){0,2}$")]
        //[GameRegularExpression(@"^[a-zA-Z]*(\s[[a-zA-Z]*)+$")]
        [Required(ErrorMessage = "Name and last name are required")]
        public string fullName { get; set; }

        //[Required(ErrorMessage = "Fisrt name is required")]
        //public string firstName { get; set; }

        //[Required(ErrorMessage = "Last name is required")]
        //public string lastName { get; set; }


        [Required(ErrorMessage = "UserName is required")]
        //add regex?
        public string userName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        //add regex?
        public string password { get; set; }

        [GameRegularExpression(@"^[\w.]+@[\w.]+\.[.a-zA-Z]+$")]
        public string email { get; set; }

        //[Required(ErrorMessage = "Date of birth is required")]
        //validation of right date
        //[RegularExpression(@"^ ((0 | 1)\d{1})-((0|1|2)\d{1})-((19|20)\d{2}")]

        public Nullable<DateTime> dateOfBirth { get; set; }

    }
}

