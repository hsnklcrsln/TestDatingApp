using System;
using System.Collections.Generic;
using DatingApp.API.Models;

namespace DatingApp.API.Dtos
{
    public class UserForDetailedDto
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string KnownAs { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastActiveDate { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhotoUrl { get; set; }
        public ICollection<Photo> Photos { get; set; }


    }
}