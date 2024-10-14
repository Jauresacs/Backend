using Microsoft.AspNetCore.Mvc;
using JobBoard.Models;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using System.Security.Claims;

namespace JobBoard.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecruteursController : ControllerBase
    {
        private readonly JobBoardContext _context;

        public RecruteursController(JobBoardContext context)
        {
            _context = context;
        }


        public IActionResult AddJob()
        {
            return Ok();
        }
        
        [Authorize]
        [HttpPost("addJob")]
        public async Task<IActionResult> AddJob([FromBody] Job job)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var user = _context.Users
                       .Include(u => u.Recruteur)
                       .FirstOrDefault(u => u.Id == userId);
            var recruteurId = user.Recruteur.Id;
            Console.WriteLine(recruteurId);
            if (recruteurId == null)
            {
                return Unauthorized(new { message = "Recruteur non authentifié" });
            }
            var recruteur = await _context.Recruteurs.FindAsync(recruteurId);
            if (recruteur == null)
            {
                return NotFound(new { message = "Recruteur non trouvé" });
            }

            job.RecruteurId = recruteur.Id;
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
                return NotFound(new { message = "Job not found" });
            }
            _context.Remove(job);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Job supprimé avec succès" });
        }
    }
}
