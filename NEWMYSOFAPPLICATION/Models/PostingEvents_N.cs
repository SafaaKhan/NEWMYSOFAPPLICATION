using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NEWMYSOFAPPLICATION.Models
{
    public class PostingEvents_N
    {
        public int ID { get; set; }
        public string PublisherName { get; set; }
        public string Title { get; set; }
        public string Information { get; set; }
        public string ImagePath { get; set; }

        [NotMapped]
        public byte[] ImageArray { get; set; }
    }
}
