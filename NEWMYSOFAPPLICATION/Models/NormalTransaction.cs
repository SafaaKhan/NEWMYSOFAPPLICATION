using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NEWMYSOFAPPLICATION.Models
{
    public class NormalTransaction
    {
        public int ID { get; set; }

        public string lbContinuing { get; set; }
        public string EntIdC { get; set; }
        public string EntNameC { get; set; }
        public string EntEmailC { get; set; }
        public string lbGraduate { get; set; }
        public string EntIdG { get; set; }
        public string EntNameG { get; set; }
        public string EntContinuingSt { get; set; }
        public string EntEmailG { get; set; }
        public string EntGraduateSt { get; set; }
        public String FilePath { get; set; }
        public String EntcontinuosTransaction { get; set; }
        public String EntGraduateTransaction { get; set; }
        public String GraduatedORContinuing { get; set; }
        public int Status { get; set; }
        public String FileExtension { get; set; }
        public string phrase { get; set; }
    }
}