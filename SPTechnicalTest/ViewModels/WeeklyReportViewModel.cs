using SPTechnicalTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPTechnicalTest.ViewModels
{
    public class WeeklyReportViewModel
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public long UKRFQs { get; set; }
        public long UKCancelledRFQs { get; set; }
        public long UKLineItems { get; set; }
        public long UKCancelledLineItems { get; set; }
        public long SARFQs { get; set; }
        public long SACancelledRFQs { get; set; }
        public long SALineItems { get; set; }
        public long SACancelledLineItems { get; set; }
    }
}