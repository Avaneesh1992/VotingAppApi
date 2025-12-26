namespace VotingAppApi.Model
{
    public class Voter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasVoted { get; set; }

        public ICollection<Vote> Votes { get; set; }
    }
}
