using CandidateApi.Services;
using FluentValidation;
using job_candidates.Data;
using job_candidates.DTOS;
using job_candidates.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace CandidateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        private readonly IValidator<CandidateDto> _validator;
        private ApplicationDbContext _context;


        public CandidatesController(ICandidateService candidateService, IValidator<CandidateDto> validator)
        {
            _candidateService = candidateService;
            _validator = validator;
        }

        [HttpPost]
        public async Task<IActionResult> UpsertCandidate(CandidateDto candidateDto)
        {
            var validationResult = await _validator.ValidateAsync(candidateDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var candidate = await _candidateService.UpsertCandidateAsync(candidateDto);
                return Ok(candidate);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
