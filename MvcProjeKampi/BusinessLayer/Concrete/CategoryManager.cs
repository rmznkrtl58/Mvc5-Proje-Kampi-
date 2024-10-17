using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{                //CategoryManager yazısına ctrl+"." yaparak generate consctutore tıkla
    public class CategoryManager : ICategoryService
    {   //Biz aslında GenericRepository'de çağırıp daha hızlı bir şekilde yapabilirdik
        //ama olay business tarafınd new'lemekten kaçınmak ve solidi ezmemek için aşağıdaki adımları takip etmek
        //gerekir

        ICategoryDal _CategoryDal;//ICategoryDal Irepositoryden kalıtım alıyor. 
                           
                              //categoryDal parametrem EfCategoryDal
                              //içerisinde belirtmiş olduğum Category sınıfından
                              //alır controller tarafında zaten yollacağız
        public CategoryManager(ICategoryDal categoryDal)
        {
            _CategoryDal = categoryDal;//_CategoryDal değişkenime ICategoryDal
                                       //interface'ime bağlı olan değerleri atadım
        }



        //İşlemler
        public void CategoryAdd(Category category)
        {
            category.CategoryStatus = true;
            _CategoryDal.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _CategoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            category.CategoryStatus = true;
             _CategoryDal.Update(category);
        }

        public Category GetById(int id)
        {
            return _CategoryDal.Get(x => x.CategoryId == id);
        }

        //GenericRepositoryde IRepositoryden Kalıtım alıyor.
        public List<Category> GetList()
        {
           return _CategoryDal.List(x=>x.CategoryStatus==true);
        }
    }
}
