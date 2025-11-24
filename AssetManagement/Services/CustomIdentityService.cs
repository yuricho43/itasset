using AssetManagement.Areas.Identity.Pages.Account;
using AssetManagement.Entities;
using AssetManagement.Data.Models.Identity;
using Microsoft.AspNetCore.Identity;
using AssetManagement.Pages;
using static AssetManagement.Constants;
using System.Collections.Generic;
using Telerik.SvgIcons;
using Telerik.Pivot.Core;

/***************************************************************************
 * (Identity Service routines)
 * Task<IdentityResult>     RegisterUserAsync(RegisterRequestModelCs regModel)
 * Task<SignInResult>       LoginAsync(string username, string password)
 * Task                     LogoutAsync()
 * Task<IdentityResult>     UpdatePasswordAsync(string username, string currentPassword, string newPassword)
 * Task<IdentityResult>     ResetPasswordAsync(string username, string newPassword)
 * Task<IdentityResult>     DeleteUserAsync(string username)
 * 
 * List<IdentityRole>       GetAllRoles()
 * Task<IdentityResult>     ChangeUserRoleAsync(UserAuthInfoModel usrModel)
 * Task<IList<string>>      GetCurrentUserRolesAsync()
 * Task<UserAuthInfoModel>  GetCurrentLoggedUser()
 * string                   GetCurrentLoginName()
 * Task<bool>               IsWorkEventEditable(string writer, string dateCreated)

 **************************************************************************/

namespace AssetManagement.Services
{

    public class CustomIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CustomIdentityService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IdentityResult> RegisterUserAsync(RegisterRequestModel regModel)
        {

            string username = regModel.UserName;
            string password = regModel.Password;
            string role = regModel.Role;

            //--- 사용자 체크
            var userExists = await _userManager.FindByNameAsync(username);
            if (userExists != null)
            {
                return IdentityResult.Failed(new IdentityError { Description = $"Failed to create user.  '{username}' already Exist." });
            }

            //--- 사용자 생성

            var user = new ApplicationUser { UserName = username };
            user.CompanyName = regModel.CompanyName;
            user.Department = regModel.Department;
            user.HangulName = regModel.HangulName;
            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                return result;
            }

            if (!await _roleManager.RoleExistsAsync(role))
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole(role));
                if (!roleResult.Succeeded)
                {
                    return IdentityResult.Failed(new IdentityError { Description = $"Failed to create role '{role}'." });
                }
            }

            // 사용자에 역할 추가
            return await _userManager.AddToRoleAsync(user, role);
        }

        public async Task<SignInResult> LoginAsync(string username, string password)
        {
            return await _signInManager.PasswordSignInAsync(username, password, isPersistent: false, lockoutOnFailure: false);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> UpdatePasswordAsync(string username, string currentPassword, string newPassword)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });
            }

            return await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        }

        public async Task<IdentityResult> ResetPasswordAsync(string username, string newPassword)
        {
            // 사용자 찾기
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });
            }

            // 비밀번호 제거
            var removePasswordResult = await _userManager.RemovePasswordAsync(user);
            if (!removePasswordResult.Succeeded)
            {
                return removePasswordResult;
            }

            // 새 비밀번호 설정
            return await _userManager.AddPasswordAsync(user, newPassword);
        }

        public async Task<IdentityResult> DeleteUserAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });
            }

            return await _userManager.DeleteAsync(user);
        }

        public List<IdentityRole> GetAllRoles()
        {
            var roles = _roleManager.Roles;
            var roleslist = roles.ToList();
            return roleslist;
        }

        public async Task<IdentityResult> ChangeUserRoleAsync(UserAuthInfoModel usrModel)
        {
            string username = usrModel.UserName;
            string newRole = usrModel.Role;

            // 사용자 찾기
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });
            }

            // 사용자의 기존 역할 가져오기
            var currentRoles = await _userManager.GetRolesAsync(user);

            // 기존 역할 제거
            var removeResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);
            if (!removeResult.Succeeded)
            {
                return removeResult;
            }

            // 새로운 역할이 존재하지 않으면 생성
            if (!await _roleManager.RoleExistsAsync(newRole))
            {
                var createRoleResult = await _roleManager.CreateAsync(new IdentityRole(newRole));
                if (!createRoleResult.Succeeded)
                {
                    return IdentityResult.Failed(new IdentityError { Description = $"Failed to create role '{newRole}'." });
                }
            }

            // 새로운 역할 추가
            return await _userManager.AddToRoleAsync(user, newRole);
        }

        public async Task<IList<string>> GetCurrentUserRolesAsync()
        {
            // 현재 로그인한 사용자 확인
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            if (user == null)
            {
                return new List<string>();
            }

            // 사용자의 역할 반환
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<UserAuthInfoModel> GetCurrentLoggedUser()
        {
            // 현재 로그인한 사용자 확인
            UserAuthInfoModel curuser = new UserAuthInfoModel();

            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            //var role = await _userManager.GetRolesAsync(user);
            return curuser;

            string username = _userManager.GetUserName(_httpContextAccessor.HttpContext.User);
            if (username == null)
                return null;
            var users = _userManager.Users.Where(t => t.UserName == username).First();
            curuser.UserName = users.UserName;
            curuser.HangulName = users.HangulName;
            curuser.Department = users.Department;
            //var role = await _userManager.GetRolesAsync(users);
            //curuser.Role = role[0].ToString();
        }

        //--- 작업일보가 편집 가능한지 체크
        //    Parameter : Role, DateCreate, User
        //    
        public async Task<bool> IsWorkEventEditable(string writer, string dateCreated)
        {
            string strRole = "None";
            var roles = await GetCurrentUserRolesAsync();
            if (roles.Count > 0)
                strRole = roles[0];
            else
                return false;   // Can not find Role


            //--- Check Editable : 1) 동일 user, 2) Manager, 3) Admin
            //                동일 user/Manager는 생성일자에서 7일 이내만 편집 가능
            //                Admin은 60일 이내 편집 가능
            int iDurAfterCreated = 100;
            string username = GetCurrentLoginName();
            if (DateTime.TryParse(dateCreated, out DateTime dtCreated))
            {
                iDurAfterCreated = (DateTime.Now - dtCreated).Days;
            }

            if (strRole == "Admin")
            {
                if (iDurAfterCreated <= 60)
                    return true;
            }
            else if (username == writer || strRole == "Manager")
            {
                if (iDurAfterCreated <= 30)
                    return true;
            }
            return false;
        }

        public async Task<string> GetCurrentLoginNamePublic()
        {
            string id = _userManager.GetUserName(_httpContextAccessor.HttpContext.User);
            if (id == null)
                return null;
            string userName = _userManager.Users.Where(t => t.UserName == id).Select(x => x.HangulName).FirstOrDefault();
            return userName;
        }



        private string GetCurrentLoginName()
        {
            string id = _userManager.GetUserName(_httpContextAccessor.HttpContext.User);
            if (id == null)
                return null;
            string userName = _userManager.Users.Where(t => t.UserName == id).Select(x => x.HangulName).FirstOrDefault();
            return userName;
        }

    }
}