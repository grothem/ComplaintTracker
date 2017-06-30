using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitizenComplaintTracker.Models
{
  public class ComplaintContext : DbContext
  {
    public ComplaintContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Complaint> Complaints { get; set; }
    public DbSet<Citizen> Citizens { get; set; }
  }
}
