using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Content
    {   [Key]
        public int ContentId { get; set; }
        public string ContentText { get; set; }
        public DateTime ContentDate { get; set; }

        public bool ContentStatus { get; set; }
        //bir içerik sadece bir başlığa bağlıdır
        public int TitleId { get; set; }
        public virtual Title Title { get; set; }

        //bir içerik bir yazara aittir
        public int? WriterId { get; set; }
        public virtual Writer Writer { get; set; }
    }
}
