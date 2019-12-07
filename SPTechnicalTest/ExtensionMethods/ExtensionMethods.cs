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
                weeklyReportVMList.Add(new IndexViewModel
                {
                    Name = user.Name,
                    Location = user.Location.StormLocationName,
                    RFQs = user.RFQs.Where(r => r.Status != "CAN" && r.RFQDate >= startDate && r.RFQDate <= endDate).ToList(),
                    CancelledRFQs = user.RFQs.Where(r => r.Status == "CAN" && r.RFQDate >= startDate && r.RFQDate <= endDate).ToList()
                });
            }

            // Return the list
            return weeklyReportVMList;
        }
    }
}