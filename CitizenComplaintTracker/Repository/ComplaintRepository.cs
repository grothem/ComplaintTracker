using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CitizenComplaintTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace CitizenComplaintTracker.Repository
{
    public class ComplaintRepository : IComplaintRepository
    {
        private ComplaintContext _context;

        public ComplaintRepository(ComplaintContext context)
        {
            _context = context;
        }

        public void AddCitizen(Citizen citizen)
        {
            _context.Citizens.Add(citizen);
        }

        public void AddComplaint(Complaint complaint)
        {
            _context.Complaints.Add(complaint);
        }

        public Citizen GetCitizen(string emailAddress)
        {
            return _context.Citizens.Where(c => c.Email == emailAddress).FirstOrDefault();
        }

        public IEnumerable<Complaint> GetComplaints()
        {
            return _context.Complaints.Include(c => c.Citizen).ToList();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
