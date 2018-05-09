using System;

namespace web_api.Models
{
    public class Memorization
    {
        public int Id { get; set; }
        public string UserGuId { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}