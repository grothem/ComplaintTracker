using CitizenComplaintTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitizenComplaintTracker.Repository
{
  public interface IComplaintRepository
  {
    IEnumerable<Complaint> GetComplaints();
    Citizen GetCitizen(string emailAddress);

    void AddComplaint(Complaint complaint);
    void AddCitizen(Citizen citizen);

    Task<bool> SaveChangesAsync();
  }
}
