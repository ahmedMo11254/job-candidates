using job_candidates.DTOS;
using job_candidates.Models;
using System.Threading.Tasks;

namespace CandidateApi.Services
{
    public interface ICandidateService
    {
        Task<Candidate> UpsertCandidateAsync(CandidateDto candidateDto);
    }
}