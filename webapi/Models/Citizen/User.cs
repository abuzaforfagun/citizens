using System;

namespace web_api.Models.Citizen
{
    public class    User
    {
        public int Id { get; set; }
        public string GuId
        {
            get; set;
        }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User()
        {
            // GuId = new Guid();
        }
        public void GenerateSH1Password(){
            Password = (this.Password + GuId.ToString()).GetHashCode().ToString();
        }
    }
}