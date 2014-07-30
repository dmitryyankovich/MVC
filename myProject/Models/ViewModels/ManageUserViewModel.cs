using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace myProject.Models.ViewModels
{
    public class ManageUserViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Firstname")]
        public string Firstname { get; set; }

        [Required]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "Nickname")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Language")]
        public ICollection<Languages> Languages { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public string Avatar { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}