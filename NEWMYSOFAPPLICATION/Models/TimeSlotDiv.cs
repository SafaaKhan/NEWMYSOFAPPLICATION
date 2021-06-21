using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NEWMYSOFAPPLICATION.Models
{
    public class TimeSlotDiv
    {
        public int ID { get; set; }
        public string time { get; set; }
        public string staffID { get; set; }
        public int roleNumber { get; set; }
        public string availability { get; set; }
        public string service { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string dateType { get; set; }
        public string WorkingDaysTupe { get; set; }
        public string Day { get; set; }
    }
}