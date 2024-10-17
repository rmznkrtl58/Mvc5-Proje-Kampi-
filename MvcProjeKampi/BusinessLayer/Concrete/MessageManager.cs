using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messagedal;

        public MessageManager(IMessageDal messagedal)
        {
            _messagedal = messagedal;
        }

        public List<Message> AdminGetListInbox(string m)
        {
            return _messagedal.List(x => x.ReceiverMail == m);
        }

        public List<Message> AdminGetListSendBox(string m)
        {
            return _messagedal.List(x => x.SenderMail == m);
        }

        public Message GetById(int id)
        {
          return _messagedal.Get(x => x.MessageId == id);
        }

        public List<Message> GetListInbox(string m)
        {
            return _messagedal.List(x=>x.ReceiverMail== m);
        }

        public List<Message> GetListSendBox(string m)
        {
            return _messagedal.List(x => x.SenderMail == m);
        }

        public void MessageAdd(Message message)
        {
            _messagedal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            throw new NotImplementedException();
        }

        public void MessageUpdate(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
