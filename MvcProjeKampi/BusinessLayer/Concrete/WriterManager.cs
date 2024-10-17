using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerdal;

        public WriterManager(IWriterDal writerdal)//EfWriter sınıfımdan
                            //yolladığım generic ve IWriterDal değerlerimi
                            //Kapsar
        {
            //IWriterDal sınıfım IRepository interfacimi miras aldı 
            //IRepositoryde->crut işlemlerinin temeli atılan yer
            //_writerdal değişkenimde IWriterDal'a bağlı olan 
            //metodları içine aktardı
            _writerdal = writerdal;
        }

        public Writer GetById(int id)
        {
            return _writerdal.Get(x => x.WriterId == id);
        }

        public List<Writer> GetListBySession(string s)
        {
            return _writerdal.List(x => x.WriterMail == s &&x.WriterStatus==true);
        }

        public void WriterDelete(Writer writer)
        {
            _writerdal.Delete(writer);
        }

        public List<Writer> WriterGetList()
        {
           return _writerdal.List();
        }

        public void WriterInsert(Writer writer)
        {
            _writerdal.Insert(writer);
        }
       
        public void WriterUpdate(Writer writer)
        {
            _writerdal.Update(writer);
        }
    }
}
