using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IAdminService
    {
        List<Admin> GetListAdmin();
        void AdminAdd(Admin a);

        void AdminDelete(Admin a);

        void AdminUpdate(Admin a);

        Admin GetById(int id);
    }
}
