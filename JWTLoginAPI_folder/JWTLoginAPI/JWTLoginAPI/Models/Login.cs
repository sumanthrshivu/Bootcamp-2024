using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JWTLoginAPI.Models;

public partial class Login
{
    [Required]
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }
}
