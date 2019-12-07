using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPTechnicalTest.Models
{
    public class Content
    {
        //Properties
        public float ID { get; set; }
        public float RFQNo { get; set; }
        public DateTime Date { get; set; }
        public float LineItem { get; set; }
        public string Description { get; set; }
        public float Quantity { get; set; }

        //Relationships
        public virtual RFQ RFQ { get; set; }
    }
}