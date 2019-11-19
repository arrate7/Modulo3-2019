using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Models
{
    public class AppUser : IdentityUser
    {
        [MaxLength(25)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }

    }
}
