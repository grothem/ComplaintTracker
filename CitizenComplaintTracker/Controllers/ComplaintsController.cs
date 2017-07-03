using CitizenComplaintTracker.Models;
using CitizenComplaintTracker.Repository;
using CitizenComplaintTracker.View_Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CitizenComplaintTracker.Controllers
{
    [Route("api/complaints")]
    public class ComplaintsController : Controller
    {
        private IComplaintRepository _repository;

        public ComplaintsController(IComplaintRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var complaints = _repository.GetComplaints();
            return Ok(AutoMapper.Mapper.Map<IEnumerable<ComplaintViewModel>>(complaints));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ComplaintViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var complaint = AutoMapper.Mapper.Map<Complaint>(vm);

                    _repository.AddCitizen(complaint.Citizen);
                    _repository.AddComplaint(complaint);

                    if (await _repository.SaveChangesAsync())
                    {
                        return Created("/api/complaints", AutoMapper.Mapper.Map<ComplaintViewModel>(complaint));
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(string.Format("An exception was caught attempting " +
                                                    "to add new complaint. {0}", ex.ToString()));
                }
            }

            return BadRequest("Failed to save the complaint");
        }
    }
}
