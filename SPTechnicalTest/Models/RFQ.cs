using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPTechnicalTest.Models
{
    public class RFQ
    {
        //Properties
        public float No { get; set; }
        public DateTime Date { get; set; }
        public float CustomerID { get; set; }
        public string AccountManager { get; set; }
        public string CreatedBy { get; set; }
        public string Status { get; set; }

        //Relationships
        public virtual List<Content> Content { get; set; }
    }
}