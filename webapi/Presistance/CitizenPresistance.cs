namespace web_api.Presistance
{
    public class CitizenPresistance
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhotoUrl { get; set; }
        public int Group { get; set; }
        public bool IsSponsorRequired { get; set; }
        public bool SupportEfforOf { get; set; }
        public bool SponsorStudent { get; set; }

    }
}