using SPTechnicalTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPTechnicalTest.ViewModels
{
    public class IndexViewModel
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public long RFQs { get; set; }
        public long CancelledRFQs { get; set; }
        public long LineItems { get; set; }
        public long CancelledLineItems { get; set; }
    }
}