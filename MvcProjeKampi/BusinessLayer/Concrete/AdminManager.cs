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
    public class AdminManager : IAdminService
    {
        IAdminDal _admindal;

        public AdminManager(IAdminDal admindal)
        {
            _admindal = admindal;
        }

        public void AdminAdd(Admin a)
        {
             _admindal.Insert(a);
        }

        public void AdminDelete(Admin a)
        {
            throw new NotImplementedException();
        }

        public void AdminUpdate(Admin a)
        {   
            _admindal.Update(a);
        }

        public Admin GetById(int id)
        {
            return _admindal.Get(x => x.AdminId == id);
        }

        public List<Admin> GetListAdmin()
        {
            return _admindal.List();
        }
    }
}
