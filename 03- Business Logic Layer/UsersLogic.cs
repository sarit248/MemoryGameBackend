using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Match_Memory_Game
{
    public class UsersLogic : BaseLogic
    {
        public UserModel AddUser(UserModel userModel)
        {
            User user = new User
            {
            
                FullName = userModel.fullName,
                UserName = userModel.userName,
                Password = userModel.password,
                Email = userModel.email,
                DateOfBirth = userModel.dateOfBirth,
            };
            DB.Users.Add(user);
            DB.SaveChanges();

            // EF-שייכת ל Product המחלקה
            // חדש, מסד הנתונים ייצר קוד עבור המוצר Product לאחר הוספת
            // שלה Product-החדש הזה  לאובייקט ה ID-אוטומטית תכניס את ה EF

            userModel.userID = user.UserID; // Set the new ID.

            // אם מסד הנתונים מייצר עוד מאפיינים עבור הרשומה, חשוב לעדכן גם אותם
            // CreationTime לדוגמה
            // אפשר במקרה כזה, פשוט לפנות למסד הנתונים, ולקבל את כל הרשומה מחדש
            return GetOneUser(user.UserID);
        }

        public bool IsUserExists(UserModel user)
        {
            return DB.Users.Where(u => (u.UserName == user.userName) || (u.Password == user.password)).Any();
        }

        public UserModel GetOneUser(int userID)
        {
            return DB.Users
                .Where(u => u.UserID == userID)
                .Select(u => new UserModel
                {
                    userID = u.UserID,
                    fullName = u.FullName,
                    userName = u.UserName,
                    password = u.Password,
                    email = u.Email,
                    dateOfBirth = u.DateOfBirth,
                }).SingleOrDefault();
        }

        public UserModel GetUser(UserModel user)
        {
            return DB.Users
                .Where(u => ((u.UserName == user.userName) || (u.Email == user.email)) && (u.Password == user.password))
                .Select(u => new UserModel
                {
                    userID = u.UserID,
                    fullName = u.FullName,
                    userName = u.UserName,
                    password = u.Password,
                    email = u.Email,
                    dateOfBirth = u.DateOfBirth,
                }).SingleOrDefault();
        }

        public List<UserModel> GetAllUsers()
        {
            return DB.Users.Select(u => new UserModel
            {
                userID = u.UserID,
                fullName = u.FullName,
                userName = u.UserName,
                password = u.Password,
                email = u.Email,
                dateOfBirth = u.DateOfBirth

            }).ToList();
        }


        //public bool GetUserByMatchingPassword(int userID)
        //{
        //להשלים
        //}
    }
}
