using VotingAppApi.Model;

namespace VotingAppApi.Services
{
    public interface IVotingService
    {
        Task<List<Candidate>> GetCandidatesAsync();
        Task<List<Voter>> GetVotersAsync();
        Task AddCandidateAsync(string name);
        Task AddVoterAsync(string name);
        Task CastVoteAsync(int candidateId, int voterId);
    }
}
