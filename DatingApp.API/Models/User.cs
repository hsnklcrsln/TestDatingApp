using System;
using System.Collections.Generic;

namespace DatingApp.API.Models
{
    public partial class User
    {
        public User()
        {
            Photo = new HashSet<Photo>();
        }

        public long Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Gender { get; set; }
        public string KnownAs { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastActiveDate { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public ICollection<Photo> Photo { get; set; }
    }
}
