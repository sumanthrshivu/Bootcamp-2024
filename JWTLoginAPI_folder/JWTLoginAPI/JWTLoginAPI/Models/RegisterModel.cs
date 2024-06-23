using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace JWTLoginAPI.Models
{
    public class RegisterModel
    {
        public int Id { get; set; }
        [Required]
        public string? Firstname { get; set; }
        [Required]
        public string? Lastname { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        //[Required]
        //[DataType(DataType.Password)]
        //[MinLength(6,ErrorMessage ="password needs to be minimum 6 character")]
        public string? Password { get; set; }
    }
}
