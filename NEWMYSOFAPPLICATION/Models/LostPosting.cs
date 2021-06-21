using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NEWMYSOFAPPLICATION.Models
{
    public class LostPosting
    {
        public int ID { get; set; }

        public string ResponsibleName { get; set; }

        public string Information { get; set; }

        public DateTime? Date { get; set; }

        public virtual ICollection<RegisterMember> RegisterMembers
        {
            get; set;
        }
    }
}