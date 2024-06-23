using System;
using System.Collections.Generic;

namespace JWTLoginAPI.Models;

public partial class Register
{
    public int Id { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }
}
