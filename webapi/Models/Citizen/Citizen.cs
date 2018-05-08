using System.Collections.Generic;

namespace web_api.Models.Citizen
{
    public class Citizen : User
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhotoUrl { get; set; }
        public int Group { get; set; } 
        public bool IsSponsorRequired { get; set; }
        public bool SupportEfforOf { get; set; }
        public bool SponsorStudent { get; set; }
        public MemorizationList MemorizationList { get; set; }

        public Citizen()
        {
            MemorizationList = new MemorizationList();
        }
    }
}