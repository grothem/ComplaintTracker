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
          var citizen = complaint.Citizen;
          if (_repository.GetCitizen(citizen.Email) == null)
          {
            _repository.AddCitizen(citizen);
          }

          complaint.Citizen = citizen;

          _repository.AddComplaint(complaint);

          if (await _repository.SaveChangesAsync())
          {
            return Created($"/api/complaints", AutoMapper.Mapper.Map<ComplaintViewModel>(complaint));
          }
        }
        catch (Exception ex)
        {
          //log exception
          return BadRequest("Failed to save the complaint");
        }
       }

      return BadRequest("Failed to save the complaint");
    }
  }
}
