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
    public class ImageManager : IImageService
    {
        IImageDal _imagedal;

        public ImageManager(IImageDal imagedal)
        {
            _imagedal = imagedal;
        }

        public List<ImageFile> GetImageList()
        {
          return _imagedal.List();
        }

        public void ImageAdd(ImageFile ımageFile)
        {
            throw new NotImplementedException();
        }
    }
}
