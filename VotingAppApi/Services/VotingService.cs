using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using VotingAppApi.Data;
using VotingAppApi.Model;

namespace VotingAppApi.Services
{
    public class VotingService : IVotingService
    {
        private readonly ApplicationDbContext _context;

        public VotingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Candidate>> GetCandidatesAsync()
            => await _context.Candidates.ToListAsync();

        public async Task<List<Voter>> GetVotersAsync()
            => await _context.Voters.ToListAsync();

        public async Task AddCandidateAsync(string name)
        {
            _context.Candidates.Add(new Candidate { Name = name });
            await _context.SaveChangesAsync();
        }

        public async Task AddVoterAsync(string name)
        {
            _context.Voters.Add(new Voter { Name = name });
            await _context.SaveChangesAsync();
        }
        public async Task CastVoteAsync(int candidateId, int voterId)
        {
            var candidateParam = new SqlParameter("@CandidateId", candidateId);
            var voterParam = new SqlParameter("@VoterId", voterId);

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_CastVote @CandidateId, @VoterId",
                candidateParam,
                voterParam
            );
        }
        public async Task CastVoteAsync_EF(int candidateId, int voterId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            var voter = await _context.Voters.FindAsync(voterId);
            if (voter == null || voter.HasVoted)
                throw new Exception("Voter already voted");

            var candidate = await _context.Candidates.FindAsync(candidateId);
            if (candidate == null)
                throw new Exception("Candidate not found");

            candidate.VoteCount++;
            voter.HasVoted = true;

            _context.Votes.Add(new Vote
            {
                CandidateId = candidateId,
                VoterId = voterId,
                VotedOn = DateTime.UtcNow
            });

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
    }

}
