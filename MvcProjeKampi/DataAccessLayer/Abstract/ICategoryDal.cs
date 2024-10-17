using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
   public interface ICategoryDal:IRepository<Category>
    {
        //Category tablom için gerekli crud işlemlerinin yapılacağı temel iskeleti tanımladığım
        //interfacedir
        //List<Category> List();

        //void Insert(Category p);
        
        //void Delete(Category p);

        //void Update(Category p);
    }
}
