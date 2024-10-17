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
    public class ContentManager : IContentService
    {
        IContentDal _contentdal;

        public ContentManager(IContentDal contentdal)
        {
            _contentdal = contentdal;
        }
        public void ContentAdd(Content content)
        {
            _contentdal.Insert(content);
        }

        public void ContentDelete(Content content)
        {
            throw new NotImplementedException();
        }

        public void ContentUpdate(Content content)
        {
            throw new NotImplementedException();
        }

        public Content FindContent()
        {
            throw new NotImplementedException();
        }

        public List<Content> GetListContent(string p)
        {
           return _contentdal.List(x=>x.Title.TitleName.Contains(p));
        }

        public List<Content> GetListContentByTitleId(int id)
        {
            return _contentdal.List(x => x.TitleId == id);
        }

        public List<Content> GetListContentByWriter(int id)
        {
            return _contentdal.List(x => x.WriterId == id);
        }
    }
}
