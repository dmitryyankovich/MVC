using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BLL.DomainModels;

namespace WebUI.ViewModels
{
    public class ViewProfileViewModel : IdModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string City { get; set; }

        public string Email { get; set; }

        public string Avatar { get; set; }

        [Display(Name = "Language")]
        public string[] Languages { get; set; }
    }
}