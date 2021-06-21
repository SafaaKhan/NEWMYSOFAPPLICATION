using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NEWMYSOFAPPLICATION.Models
{
    public class TimeSlots
    {
        public int ID { get; set; }
        public string staffID { get; set; }
        public int startTime { get; set; }
        public int endtTime { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string dateType { get; set; }
        public int slots { get; set; }
        public string service { get; set; }
        public string WorkingDaysTupe { get; set; }
        public string Day { get; set; }
        public int breakstartTime { get; set; }
        public int breakendtTime { get; set; }
        public DateTime disableStartDate { get; set; }
        public DateTime disableEndDate { get; set; }
        public bool disablestatus { get; set; }
        public string disableMSG { get; set; }
    }
}