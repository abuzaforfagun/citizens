using System.Collections.Generic;

namespace web_api.Models.Citizen
{
    public class MemorizationList
    {
        public List<Memorization> Memorized { get; set; }
        public List<Memorization> MemorizationGoal { get; set; }

        public MemorizationList()
        {
            Memorized = new List<Memorization>();
            MemorizationGoal = new List<Memorization>();
        }
    }
}