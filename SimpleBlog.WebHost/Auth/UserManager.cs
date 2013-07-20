using System.Text.RegularExpressions;
using System.Web;
using System.Web.SessionState;
using Fullback.WebHost.Models;
using Rock.Framework.DirectoryServices;

namespace Fullback.WebHost.Auth
{
    public static class UserManager
    {
        private static User _currentUser;

        public static User GetCurrentUser(HttpSessionState session)
        {
            if (session["currentUser"] == null || ((User)session["currentUser"]).CommonId <= 0)
            {
                SetCurrentUser(session);
            }
            return (User)session["currentUser"];
        }

        public static void SetCurrentUser(HttpSessionState session)
        {
            using (var userRepo = new ActiveDirectoryRepository<User>())
            {
                if (HttpContext.Current.Request.LogonUserIdentity != null)
                {
                    _currentUser = userRepo.GetByUserName(GetUserName(HttpContext.Current.Request.LogonUserIdentity.Name));
                    //_currentUser.UserPermission = GetUserPermissions(_currentUser.CommonId);
                }
            }
            session["currentUser"] = _currentUser;
        }

        public static bool IsUserAuthenticated(UserLoginModel userLogin)
        {
            var auth = new ActiveDirectoryAuthenticator(userLogin.Username, userLogin.Password);
            return auth.IsAuthenticated;
        }

        private static string GetUserName(string domainUser)
        {
            var userParts = Regex.Split(domainUser, "\\\\");
            return userParts.Length > 1 ? userParts[1] : userParts[0];
        }

        //private static UserPermission GetUserPermissions(int commonId)
        //{
        //    var repository = new RepositoryLocator();
        //    return repository.UserPermissionRepository.GetById(commonId);
        //}
    }
}