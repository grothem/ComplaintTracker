using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitizenComplaintTracker.Models
{
    public static class DbInitializer
    {
        public static void Initialize(ComplaintContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Complaints.Any())
            {
                context.Citizens.Add(new Citizen
                {
                    FirstName = "John",
                    LastName = "Smith",
                    Email = "jsmith@gmail.com",
                    PhoneNumber = "5635991122"
                });

                context.Citizens.Add(new Citizen()
                {
                    FirstName = "LeBron",
                    LastName = "James",
                    Email = "kingjames@gmail.com",
                    PhoneNumber = "5635832111"
                });

                context.SaveChanges();

                var complaints = new List<Complaint>
                {
                    new Complaint {
                        Details ="There is a knocked over stop sign",
                        IssueLocation ="Grandview and Delhi",
                        IssueType = "Signs",
                        Citizen = context.Citizens.Single(c => c.Email == "jsmith@gmail.com")},
                    new Complaint {
                        Details ="There are no nets on the basketball hoops",
                        IssueLocation ="Flora Park",
                        IssueType = "Parks & Rec",
                        Citizen = context.Citizens.Single(c => c.Email == "kingjames@gmail.com")}
                };

                context.Complaints.AddRange(complaints);
                context.SaveChanges();
            }
        }
    }
}
