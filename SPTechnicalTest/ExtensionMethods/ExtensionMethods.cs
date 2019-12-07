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
        public static List<WeeklyReportViewModel> GetWeeklyReportsUKSA (this List<User> users, 
            DateTime startDate, DateTime endDate,
            StormContext db)
        {
            // Declare a list of weekly reports and populate it according to the users and date parameters
            var weeklyReportVMList = new List<WeeklyReportViewModel>();
            foreach (var user in users)
            {
                var weeklyReportVM = new WeeklyReportViewModel 
                { 
                    Name = user.Name, 
                    Location = user.Location.StormLocationName
                };

                foreach(var rfq in db.RFQs.Where(r => r.LoginID == user.LoginID && r.RFQDate > startDate && r.RFQDate < endDate))
                {
                    if (rfq.Status == "CAN")
                    {
                        if(rfq.AccountManager.EndsWith("UK"))
                        {
                            weeklyReportVM.UKRFQs++;
                            rfq.Content.ForEach(c => weeklyReportVM.UKLineItems += Convert.ToInt64(c.Qty));
                        }
                        else if(rfq.AccountManager.EndsWith("SA"))
                        {
                            weeklyReportVM.SARFQs++;
                            rfq.Content.ForEach(c => weeklyReportVM.SALineItems += Convert.ToInt64(c.Qty));
                        }
                            
                    }
                    else
                    {
                        if (rfq.AccountManager.EndsWith("UK"))
                        {
                            weeklyReportVM.UKCancelledRFQs++;
                            rfq.Content.ForEach(c => weeklyReportVM.UKCancelledLineItems += Convert.ToInt64(c.Qty));
                        }
                        else if (rfq.AccountManager.EndsWith("SA"))
                        {
                            weeklyReportVM.SACancelledRFQs++;
                            rfq.Content.ForEach(c => weeklyReportVM.SACancelledLineItems += Convert.ToInt64(c.Qty));
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