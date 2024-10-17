using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{  //Doğru Kullanım
    public class GenericRepository<T> : IRepository<T> where T : class//implement etmeyi unutma
    {                                           //benim T değerim class olmalıdır

        Context ent = new Context();
        DbSet<T> _object;
        public GenericRepository()//constructor metod sınıfımla aynı ismi alan (ctor)
        {
            _object = ent.Set<T>();//Contexte bağlı olarak gönderilen T değerim
            //object adındaki fieldım dışardan gönderdiğim entity neyse o olacak 
        }
        public void Delete(T p)
        {
            var DeletedEntity = ent.Entry(p);
            DeletedEntity.State = EntityState.Deleted;
            //_object.Remove(p);
            ent.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)//bulma getirme
        {
            return _object.SingleOrDefault(filter);
            //şartıma göre bir değer getir 5 numaralı id'yi getir gibi
        }

        public void Insert(T p)
        {
            var AddedEntity = ent.Entry(p);//ekliyeceğim değeri değişkene atadık
            AddedEntity.State = EntityState.Added;
            //_object.Add(p);
            ent.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> Filter)
        {
            return _object.Where(Filter).ToList();//filterda hangi şartı gönderirsem
                                        //ona göre listeleyecek
        }

        public void Update(T p)
        {
            var UpdatedEntity = ent.Entry(p);
            UpdatedEntity.State = EntityState.Modified;
            ent.SaveChanges();
        }
    }
}
