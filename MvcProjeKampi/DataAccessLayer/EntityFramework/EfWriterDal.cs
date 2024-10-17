using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{  //burası bizi businesdaki manager sınıflarımdaki göndereceğim
   //Parametreyi burada belirliyorum
    public class EfWriterDal:GenericRepository<Writer>,IWriterDal
    {

    }
}
