﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IImageService
    {
        List<ImageFile> GetImageList();

        void ImageAdd(ImageFile ımageFile);
    }
}
