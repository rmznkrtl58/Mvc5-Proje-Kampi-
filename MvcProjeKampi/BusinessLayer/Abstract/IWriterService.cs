using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IWriterService
    {   //busines katmanında yapacağım işlemlerin iskeletini tanımladığım alan
        List<Writer> WriterGetList();
        void WriterInsert(Writer writer);
        void WriterDelete(Writer writer);
        void WriterUpdate(Writer writer);
        Writer GetById(int id);
        List<Writer> GetListBySession(string s);

    }
}
