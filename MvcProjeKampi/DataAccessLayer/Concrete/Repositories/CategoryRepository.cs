using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{   //YANLIŞ KULLANIM GENERİC DAHA MANTIKLI
    public class CategoryRepository : ICategoryDal//->implement etmeyi unutma
    {   //Category tablom için crud işlemlerinin görevlerini tanımladığım alan
        Context ent = new Context();
        DbSet<Category> _object;//DbSet türünde category tablomun verilerini kapsayan 
                                //_object değişkenimi tanımladım

        public void Delete(Category p)
        {
            _object.Remove(p);
            ent.SaveChanges();
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(Category p)
        {
            _object.Add(p);
            ent.SaveChanges();
        }

        public List<Category> List()
        {
           return _object.ToList();
        }

        public List<Category> List(Expression<Func<Category, bool>> Filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Category p)
        {
            ent.SaveChanges();
        }
    }
}
