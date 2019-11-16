using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SafetracMVCApp.Models
{
    public class UserModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [EmailAddress]
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email address is required.")]
        public string Email { get; set; }
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}