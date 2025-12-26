namespace VotingAppApi.Model
{
    public class Vote
    {
        public int Id { get; set; }

        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }

        public int VoterId { get; set; }
        public Voter Voter { get; set; }

        public DateTime VotedOn { get; set; }
    }
}
