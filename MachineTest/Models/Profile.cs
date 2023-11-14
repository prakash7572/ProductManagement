using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Models
{
    public class Profile
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class LoginVM 
    {
       public string Email { get; set; }
       public string Password { get; set; }
    }
    public class ChangePassword
    {
        [Key]
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}