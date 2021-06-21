using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NEWMYSOFAPPLICATION.Models
{
    public class StudentReservedAppointment
    {
        public int ID { get; set; }
        public string studentID { get; set; }//t
        public string studentName { get; set; }
        public string StudentEmail { get; set; }
        public string staffName { get; set; }
        public string serviceName { get; set; }
        public string Date { get; set; }//t
        public string Time { get; set; }//t
        public bool status { get; set; }
        public string isDone { get; set; }
        public string availability { get; set; }
        public bool isVisibale { get; set; }
        public int roleNumber { get; set; }
        public string WorkingDaysTupe { get; set; }
        public string Day { get; set; }
        public string isDoneby { get; set; }
        public string isCancelledby { get; set; }
    }
}