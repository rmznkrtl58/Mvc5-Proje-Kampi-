﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IAboutService
    {
        List<About> GetAboutList();

        void InsertAbout(About about);

        void DeleteAbout(About about);

        void UpdateAbout(About about);

        About GetById();

    }
}
