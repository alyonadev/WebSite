using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.DBModels;

namespace ModelsWithMapper.Mapper
{
    public class MessageMapper
    {
        public static Message ToMessage(MessageModel messageModel)
        {
            Message newMessage = new Message
            {
                MessageId = messageModel.MessageId,
                From = messageModel.From,
                To = messageModel.To,
                Text = messageModel.Text,
                Date = messageModel.Date
            };

            return newMessage;

        }

        public static MessageModel ToMessageModel(Message message)
        {
            MessageModel newMessage = new MessageModel
            {
                MessageId = message.MessageId,
                From = message.From,
                To = message.To,
                Text = message.Text,
                Date = message.Date
            };

            return newMessage;
        }

        public static IEnumerable<Message> ToMessageList(IEnumerable<MessageModel> messageModels)
        {
            List<Message> message = new List<Message>();

            foreach (var mm in messageModels)
            {
                message.Add(ToMessage(mm));
            }

            return message.AsEnumerable();
        }

        public static IEnumerable<MessageModel> ToUserModelList(IEnumerable<Message> messages)
        {
            List<MessageModel> messageModels = new List<MessageModel>();

            foreach (var mm in messages)
            {
                messageModels.Add(ToMessageModel(mm));
            }

            return messageModels.AsEnumerable();
        }
    }
}
