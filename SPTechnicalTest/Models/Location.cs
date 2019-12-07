using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPTechnicalTest.Models
{
    public class Location
    {
        //Properties
        public float ID { get; set; }
        public string Name { get; set; }

        //Relationships
        public virtual List<User> User { get; set; }
    }
}