using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CitizenComplaintTracker.Models
{
    public class Complaint
    {
        public int Id { get; set; }
        public string IssueType { get; set; }
        public string IssueLocation { get; set; }
        public string Details { get; set; }

        [ForeignKey("CitizenId")]
        public Citizen Citizen { get; set; }
    }
}
