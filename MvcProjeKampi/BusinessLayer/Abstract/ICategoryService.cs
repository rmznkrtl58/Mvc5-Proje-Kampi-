using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface ICategoryService
    {   //business katmanımda yapılacak işlemlerin iskeletlerini tanımladığım yer
        List<Category> GetList();

        void CategoryAdd(Category category);

        Category GetById(int id);//getirme bulma işlemi

        void CategoryDelete(Category category);

        void CategoryUpdate(Category category);

    }
}
