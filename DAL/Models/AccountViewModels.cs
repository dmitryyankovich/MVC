using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace myProject.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
    }
}
