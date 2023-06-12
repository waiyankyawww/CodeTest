using System;
using System.ComponentModel.DataAnnotations;

namespace FarmFresh.Models
{
	public class LogIn
        {
            [Required]    
            public required string Email { get; set; }
            [Required]
            public required string Password { get; set; }
            public bool RememberMe { get; set; }
        }
}

