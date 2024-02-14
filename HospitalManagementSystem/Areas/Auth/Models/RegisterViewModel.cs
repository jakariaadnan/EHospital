using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PatientManagement.Areas.Auth.Models
{
    public class RegisterViewModel
    {
        public string? FullName { get; set; }

        public string? Citizenship { get; set; }

        public int? NationalIdentityType { get; set; }

        public string? NationalIdentityNo { get; set; }
        public int? AddressType { get; set; }

        public IFormFile formFile { get; set; }

        public string? PhoneNumber { get; set; }
        public string? UserOTPCode { get; set; }

        public string? PassportNo { get; set; }
        public IFormFile image { get; set; }

        public string? Email { get; set; }

        public int? UserTypeId { get; set; }
        public int? UserId { get; set; }

        public string? RoleId { get; set; }
        public string? verifyMessage { get; set; }

        public DateTime? dob { get; set; }

        public string? UserName { get; set; }
        public string? OldPassword { get; set; }

        public string?[] assignRoles { get; set; }
        public string?[] removeRoles { get; set; }


        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [MinLength(6)]
        [Display(Name = "Password")]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [MinLength(6)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }
        
    }
}
