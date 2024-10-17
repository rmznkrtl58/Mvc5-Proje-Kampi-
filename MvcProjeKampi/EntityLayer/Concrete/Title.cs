using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Title
    {   [Key]
        public int TitleId { get; set; }
        [StringLength(100)]
        public string TitleName { get; set; }
        public DateTime TitleDate { get; set; }

        //bir başlık sadece bir kategoriye bağlıdır(bire çok ilişki "bir")
        public int CategoryId { get; set; }//->Category sınıfımdaki isimle aynı olmalı
        public virtual Category Category { get; set; }

        //Bir başlıkta birden fazla içerik bulunabilir
        public ICollection<Content> contents { get; set; }

        //Bir başlık sadece bir yazara aittir
        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }
        public bool TitleStatus { get; set; }
    }
}
