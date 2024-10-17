using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{  //Doğru Kullanımdır
   public interface IRepository<T>
    {
        List<T> List();

        void Insert(T p);

        void Delete(T p);

        void Update(T p);

        List<T> List(Expression<Func<T, bool>> Filter);
        //using.system.linq //booldan maksatta istediğim şartlar sağlanıyorsa
        //bool true gelecek ve o istediğim şarttaki verileri listeleyecek

        T Get(Expression<Func<T, bool>> filter);//bulma işlemi(getirme)
    }
}
