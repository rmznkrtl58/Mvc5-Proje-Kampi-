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
    public class TitleManager : ITitleService
    {
        ITitleDal _titledal;

        public TitleManager(ITitleDal titledal)
        {
            _titledal = titledal;
        }

        public void DeleteTitle(Title title)
        {
            title.TitleStatus = false;
            _titledal.Update(title);
        }

        public Title GetById(int id)
        {
            return _titledal.Get(x => x.TitleId == id);
        }

        public List<Title> GetTitleList()
        {
            return _titledal.List(x=>x.TitleStatus==true);
        }

        public List<Title> GetTitleListByWriter(int id)
        {
            return _titledal.List(x => x.WriterId ==id&&x.TitleStatus==true );
        }

        public void InsertTitle(Title title)
        {
            title.TitleStatus = true;
            _titledal.Insert(title);
        }

        public List<Title> titlewriterlist(int id)
        {
            return _titledal.List(x => x.TitleId ==id);
        }

        public void UpdateTitle(Title title)
        {
           
            _titledal.Update(title);
        }
    }
}
