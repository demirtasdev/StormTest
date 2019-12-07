using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPTechnicalTest.Models
{
    public class User
    {
        //Properties
        public double ID { get; set; }
        public string LoginID { get; set; }
        public string Name { get; set; }
        public double StormLocationID { get; set; }

        //Relationships
        public virtual Location Location { get; set; }
        public virtual List<RFQ> RFQs { get; set; }
    }
}