using Microsoft.AspNetCore.Mvc;
using JobBoard.Models;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;

namespace JobBoard.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecruteursControler: ControllerBase
    {
        private readonly JobBoardContext _context;

        public RecruteursControler(JobBoardContext context)
        {
            _context = context;
        }
     

        public IActionResult AddJob()
        {
            return Ok();
        }

        [HttpPost("addJob")]
        public async Task<IActionResult> AddJob([FromBody] Job job)
        {
                var recruteurId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

                if (recruteurId == null)
                {
                    return Unauthorized(new { message = "Recruteur non authentifié" });
                }

                job.RecruteurId = int.Parse(recruteurId);
                
                _context.Add(job);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Job rajouté avec succès" });
        }

        [Authorize]
        [HttpPost("deleteJob")]
        public async Task<IActionResult> DeleteJob()
        {
            var recruteurId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (recruteurId == null)
            {
                return Unauthorized(new { message = "Recruteur non authentifié" });
            }
            var job = _context.Jobs.Find(int.Parse(recruteurId));
            if (job == null)
            {
                return NotFound(new {message = "Job not found"});
            }
            _context.Remove(job);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Job supprimé avec succès" });
        }
    }
}
