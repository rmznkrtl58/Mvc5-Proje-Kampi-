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
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutdal;

        public AboutManager(IAboutDal aboutdal)
        {
            _aboutdal = aboutdal;
        }

        public void DeleteAbout(About about)
        {
            throw new NotImplementedException();
        }

        public List<About> GetAboutList()
        {
            throw new NotImplementedException();
        }

        public About GetById()
        {
            return _aboutdal.Get(x => x.AboutId == 1);
        }

        public void InsertAbout(About about)
        {
            throw new NotImplementedException();
        }

        public void UpdateAbout(About about)
        {    
            _aboutdal.Update(about);
        }
    }
}
