using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface ITitleService
    {
        List<Title> GetTitleList();
        List<Title> GetTitleListByWriter(int id);

        void InsertTitle(Title title);

        void DeleteTitle(Title title);

        void UpdateTitle(Title title);

        Title GetById(int id);

        List<Title> titlewriterlist(int id);
    }
}
