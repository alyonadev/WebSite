﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSite.DBModels;

namespace WebSite.Models
{
    public class MessageModel
    {
        public int MessageId { get; set; }

        public int From { get; set; }
        public string UserNameFrom { get; set; }

        public int To { get; set; }
        public string UserNameTo { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

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

        public static IEnumerable<Message> ToMessageList(IEnumerable<MessageModel> messageModel)
        {
            List<Message> messages = new List<Message>();
            foreach (var mm in messageModel) messages.Add(ToMessage(mm));
            return messages.AsEnumerable();
        }

        public static IEnumerable<MessageModel> ToMessageModelList(IEnumerable<Message> messages)
        {
            List<MessageModel> messageModels = new List<MessageModel>();
            foreach (var mm in messages) messageModels.Add(ToMessageModel(mm));
            return messageModels.AsEnumerable();
        }

    }
}