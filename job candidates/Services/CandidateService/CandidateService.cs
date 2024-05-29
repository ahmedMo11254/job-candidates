using job_candidates.Data;
using job_candidates.DTOS;
using job_candidates.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CandidateApi.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ApplicationDbContext _context;

        public CandidateService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Candidate> UpsertCandidateAsync(CandidateDto candidateDto)
        {
            try
            {
                if (candidateDto == null)
                {
                    throw new ArgumentNullException(nameof(candidateDto));
                }

                var existingCandidate = await _context.Candidates
                    .FirstOrDefaultAsync(c => c.Email == candidateDto.Email);

                if (existingCandidate != null)
                {
                    existingCandidate.FirstName = candidateDto.FirstName;
                    existingCandidate.LastName = candidateDto.LastName;
                    existingCandidate.PhoneNumber = candidateDto.PhoneNumber;
                    existingCandidate.PreferredCallTime = candidateDto.PreferredCallTime;
                    existingCandidate.LinkedInProfile = candidateDto.LinkedInProfile;
                    existingCandidate.GitHubProfile = candidateDto.GitHubProfile;
                    existingCandidate.Comment = candidateDto.Comment;

                    _context.Candidates.Update(existingCandidate);
                }
                else
                {
                    var candidate = new Candidate
                    {
                        FirstName = candidateDto.FirstName,
                        LastName = candidateDto.LastName,
                        PhoneNumber = candidateDto.PhoneNumber,
                        Email = candidateDto.Email,
                        PreferredCallTime = candidateDto.PreferredCallTime,
                        LinkedInProfile = candidateDto.LinkedInProfile,
                        GitHubProfile = candidateDto.GitHubProfile,
                        Comment = candidateDto.Comment
                    };

                    _context.Candidates.Add(candidate);
                }

                await _context.SaveChangesAsync();
                return existingCandidate ?? new Candidate
                {
                    FirstName = candidateDto.FirstName,
                    LastName = candidateDto.LastName,
                    PhoneNumber = candidateDto.PhoneNumber,
                    Email = candidateDto.Email,
                    PreferredCallTime = candidateDto.PreferredCallTime,
                    LinkedInProfile = candidateDto.LinkedInProfile,
                    GitHubProfile = candidateDto.GitHubProfile,
                    Comment = candidateDto.Comment
                };
            }
            catch (Exception)
            {

                throw;
            }



        }
    }
}
