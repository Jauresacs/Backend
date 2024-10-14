using Microsoft.AspNetCore.Mvc;
using JobBoard.Models;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;

namespace JobBoard{
    
    [Route("[controller]")]
    [ApiController]
    public class JobsController : ControllerBase {
        private readonly JobBoardContext _context;

             public JobsController(JobBoardContext context)
        {
            _context = context;
        }



        [HttpGet("GetAllOffers")]
        public async Task<IActionResult> GetAllOffers(){
            var jobs = await _context.Jobs.ToListAsync();
            return Ok(jobs);
        }

    }
    
}