using System.ComponentModel.DataAnnotations;

using static AssetManagement.Data.Models.ErrorMessages;
using static AssetManagement.Constants.Common;
using static AssetManagement.Constants.Identity;

namespace AssetManagement.Data.Models.Identity
{

    public class RegisterRequestModel
    {
        [Required]
        [StringLength(MaxUserNameLength, MinimumLength = MinUserNameLength, ErrorMessage = IdLengthErrorMessage)]
        public string UserName { get; set; } //login name (Employee Number)

        [Required]
        [MinLength(MinPasswordLength, ErrorMessage = PasswordLengthErrorMessage)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(MaxRoleNameLength, MinimumLength = MinRoleNameLength, ErrorMessage = StringLengthErrorMessage)]
        public string Role { get; set; }

        [Required]
        [StringLength(MaxNameLength, MinimumLength = MinNameLength, ErrorMessage = NameLengthErrorMessage)]
        public string Department { get; set; }
        [Required]
        [StringLength(MaxNameLength, MinimumLength = MinNameLength, ErrorMessage = NameLengthErrorMessage)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(MaxNameLength, MinimumLength = MinNameLength, ErrorMessage = NameLengthErrorMessage)]
        public string HangulName { get; set; }

    }

}
