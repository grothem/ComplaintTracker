using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CitizenComplaintTracker.View_Models
{
    public class ComplaintViewModel
    {
        public string IssueType { get; set; }
        public string IssueLocation { get; set; }
        public string Details { get; set; }
        public CitizenViewModel Citizen { get; set; }
    }
}
