using System;
using System.Collections.Generic;

namespace DatingApp.API.Models
{
    public partial class Photo
    {
        public long Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime? DateAdded { get; set; }
        public bool? IsMain { get; set; }
        public long? UserId { get; set; }

        public User User { get; set; }
    }
}
