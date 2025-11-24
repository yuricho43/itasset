using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Data.Models.Identity
{
    public class UserAuthInfoModel
    {
        public string UserName { get; set; }    // Id

        public string Password { get; set; }

        public string Role { get; set; }

        public string HangulName { get; set; }
        public string CompanyName { get; set; }
        public string Department { get; set; }
    }
}
