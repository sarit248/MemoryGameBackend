using System;
using System.ComponentModel.DataAnnotations;

namespace Match_Memory_Game
{
    public  class MessageModel
    {

        public MessageModel()
        {
            email = null;
        }

        public int messageID { get; set; }

        [GameRegularExpression(@"^05\d-?[1-9]\d{6}$")]
        public string phone { get; set; }


        [GameRegularExpression(@"^[\w.]+@[\w.]+\.[.a-zA-Z]+$")]
        public string email { get; set; }


        [MinLength(4, ErrorMessage = "Min length must be four chars.")]
        [MaxLength(50, ErrorMessage = "Max length must be 50 chars.")]
        public string message { get; set; }
    

        public DateTime dateAdded { get; set; }


    
        }

    }




//Regex MailRegex = new Regex(@"^[\w.]+@[\w.]+\.[.a-zA-Z]+$");

//Console.Write("Enter your mail: ");
//            string mobile = Console.ReadLine();

//            if(regex.IsMatch(mail))
//            {
//                Console.WriteLine("Valid mail :-)");
//            }
//            else
//            {
//                Console.WriteLine("Invalid mail :-(");
//            }





//Regex PhoneRegex = new Regex(@"^05\d-?[1-9]\d{6}$");

//Console.Write("Enter your phone: ");
//            string mobile = Console.ReadLine();

//            if(regex.IsMatch(phone))
//            {
//                Console.WriteLine("Valid phone :-)");
//            }
//            else
//            {
//                Console.WriteLine("Invalid phone :-(");
//            }
