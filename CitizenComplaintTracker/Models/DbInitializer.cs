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
          PhoneNumber = "5635990458"
        });

        context.SaveChanges();

        var complaints = new List<Complaint>
                {
                    new Complaint {
                        Details ="There is Graffiti",
                        IssueLocation ="On the bridge",
                        IssueType = "Graffiti",
                        Citizen = context.Citizens.First() },
                    new Complaint {
                        Details ="There is a broken sign",
                        IssueLocation ="On Main st.",
                        IssueType = "TrafficSigns",
                        Citizen = context.Citizens.First() }
                };

        context.Complaints.AddRange(complaints);
        context.SaveChanges();
      }
    }
  }
}
