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
    public class CandidatsController
    {
        private readonly JobBoardContext _context;

        public CandidatsController(JobBoardContext context)
        {
            _context = context;
        }
    }
}
