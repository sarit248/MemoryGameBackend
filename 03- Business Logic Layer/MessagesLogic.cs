using System.Collections.Generic;
using System.Linq;


namespace Match_Memory_Game
{
   public class MessagesLogic:BaseLogic
    {
        public List<MessageModel> GetAllMessages()
        {
            return DB.Messages.Select(m => new MessageModel
            {
                messageID = m.MessageID,
                phone = m.Phone,
                email=m.Email,
                message = m.Message1,
                dateAdded=m.DateAdded

            }).ToList();
        }



        public MessageModel GetOneMessage(int id)
        {
            return DB.Messages
                .Where(m => m.MessageID == id)
                .Select(m => new MessageModel
                {
                    messageID = m.MessageID,
                    phone = m.Phone,
                    email = m.Email,
                    message = m.Message1,
                    dateAdded = m.DateAdded

                }).SingleOrDefault();
        }



        public MessageModel AddMessage(MessageModel messageModel)
        {
            Message message = new Message
            {
               MessageID= messageModel.messageID,
               Phone= messageModel.phone,
               Email= messageModel.email,
               Message1 = messageModel.message,
               DateAdded= messageModel.dateAdded
            
            };
            DB.Messages.Add(message);
            DB.SaveChanges();

            messageModel.messageID = message.MessageID;
            return GetOneMessage(message.MessageID);

        }
    }
}
