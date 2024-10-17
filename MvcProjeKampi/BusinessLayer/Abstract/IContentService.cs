using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IContentService
    {
        List<Content> GetListContent(string p);
        List<Content> GetListContentByWriter(int id);

        List<Content> GetListContentByTitleId(int id);

        Content FindContent();

        void ContentAdd(Content content);

        void ContentDelete(Content content);

        void ContentUpdate(Content content);

    }
}
