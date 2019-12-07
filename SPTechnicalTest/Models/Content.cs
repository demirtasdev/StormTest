using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPTechnicalTest.Models
{
    public class Content
    {
        //Properties
        public double ID { get; set; }
        public double RFQNo { get; set; }
        public DateTime Date { get; set; }
        public double LineItem { get; set; }
        public string Description { get; set; }
        public double Qty { get; set; }

        //Relationships
        public virtual RFQ RFQ { get; set; }
    }
}