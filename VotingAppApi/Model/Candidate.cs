namespace VotingAppApi.Model
{
    public class Candidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int VoteCount { get; set; }

        public ICollection<Vote> Votes { get; set; }
    }
}
