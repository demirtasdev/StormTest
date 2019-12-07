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
        public List<RFQ> RFQs { get; set; }
        public List<RFQ> CancelledRFQs { get; set; }
    }
}