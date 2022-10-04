using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZE.ADO.NetModels;

namespace EZE.Repositories
{
    class MessageRepository
    {
        private EZEEntities9 context;
        private static MessageRepository instance = null;

        private MessageRepository()
        {
            context = new EZEEntities9();
        }

        public static MessageRepository getInstance()
        {
            if (instance == null)
            {
                instance = new MessageRepository();
            }
            return instance;
        }

        public List<MessagesTable> getMessages()
        {
            List<MessagesTable> messages = context.MessagesTables.OrderByDescending(m => m.DateReceived).ToList();
            return messages;
        }
        public List<MessagesTable> getMessagesByDate(DateTime dt)
        {
            List<MessagesTable> messages = context.MessagesTables.Where(m => m.DateReceived.Year == dt.Year
                                                            && m.DateReceived.Month == dt.Month
                                                            && m.DateReceived.Day == dt.Day)
                                                     .OrderByDescending(m => m.DateReceived)
                                                     .ToList();
            return messages;
        }

        public List<MessagesTable> getMessagesByDateAndSender(DateTime dt, string number)
        {
            List<MessagesTable> messages = context.MessagesTables.Where(m => m.DateReceived.Year == dt.Year
                                                            && m.DateReceived.Month == dt.Month
                                                            && m.DateReceived.Day == dt.Day
                                                            && m.Sender == number)
                                                     .OrderByDescending(m => m.DateReceived)
                                                     .ToList();
            return messages;
        }

        public List<MessagesTable> getMessagesByCode(string code)
        {
            List<MessagesTable> messages = context.MessagesTables.Where(m => m.Code == code).ToList();
            return messages;
        }

        public void addMessage(MessagesTable message)
        {
            context.MessagesTables.Add(message);
            context.SaveChanges();
        }
    }
}