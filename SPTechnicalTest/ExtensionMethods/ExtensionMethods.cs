using SPTechnicalTest.DataAccessLayer;
using SPTechnicalTest.Models;
using SPTechnicalTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPTechnicalTest
{
    public static class WeeklyReportExtensionMethods
    {
        public static List<IndexViewModel> GetWeeklyReports(this List<User> users, DateTime startDate, DateTime endDate, StormContext db)
        {
            // Declare a list of weekly reports and populate it according to the users and date parameters
            var weeklyReportVMList = new List<IndexViewModel>();
            foreach (var user in users)
            {
                var weeklyReportVM = new IndexViewModel
                {
                    Name = user.Name,
                    Location = user.Location.StormLocationName,
                    RFQs = 0,
                    CancelledRFQs = 0,
                    LineItems = 0,
                    CancelledLineItems = 0
                };

                //Set the RFQs, CancelledRFQs, LineItems, and CancelledLineItems properties
                foreach(var rfq in db.RFQs)
                {
                    if(rfq.User == user && rfq.RFQDate >= startDate && rfq.RFQDate <= endDate)
                    {
                        if (rfq.Status == "CAN")
                        {
                            weeklyReportVM.RFQs++;
                            rfq.Content.ForEach(c => weeklyReportVM.LineItems += Convert.ToInt64(c.Qty));
                        }
                        else
                        {
                            weeklyReportVM.CancelledRFQs++;
                            rfq.Content.ForEach(c => weeklyReportVM.CancelledLineItems += Convert.ToInt64(c.Qty));
                        }
                    }
                }
                
                //Add the newly populated WeeklyReportVM to the list declared at the beginning
                weeklyReportVMList.Add(weeklyReportVM);
            }

            // Return the list
            return weeklyReportVMList;
        }
    }
}