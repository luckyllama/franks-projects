using System;
using System.Security.Principal;
using System.Web.Mvc;
using LuckyWiki.Authentication;
using LuckyWiki.Data;
using LuckyWiki.Mvc;

namespace LuckyWiki.Web.Controllers {

    [HandleError]
    public class AccountController : LuckyWikiBaseController {

        public AccountController() : base() { }

        // only for unit testing
        public AccountController(IMembershipRepository MembershipRepository, IFormsAuthentication FormsAuthentication) {
            this.MembershipRepository = MembershipRepository;
            this.FormsAuthentication = FormsAuthentication;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Login() {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Login(string username, string password, bool rememberMe, string returnUrl) {
            if (ValidateLogOn(username, password)) {
                FormsAuthentication.SignIn(username, rememberMe);

                if (!string.IsNullOrEmpty(returnUrl) && returnUrl.StartsWith("/")) {
                    return Redirect(returnUrl);
                } else {
                    return RedirectToAction("Index", "Home");
                }
            }

            ViewData["rememberMe"] = rememberMe;

            return View();
        }

        public ActionResult LogOut() {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }

        public ActionResult Register() {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Register(string username, string email) {
            if (ValidateRegistration(username, email)) {
                IUser newUser = MembershipRepository.CreateUser();
                newUser.Username = username;
                newUser.Email = email;
                newUser.Status = UserStatus.Normal;

                string password = generatePassword();
                MembershipRepository.RegisterUser(newUser, password);
                MembershipRepository.Save();

                FormsAuthentication.SignIn(username, false /* createPersistentCookie */);
                return RedirectToAction("Index", "Home");
            }

            // If we got this far, something failed, redisplay form
            return View();
        }

        public string generatePassword() {
            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            Random randNum = new Random();
            char[] chars = new char[8];
            int allowedCharCount = allowedChars.Length;

            for (int i = 0; i < chars.Length; i++) {
                chars[i] = allowedChars[(int)((allowedChars.Length) * randNum.NextDouble())];
            }

            return new string(chars);
        }

        [Authorize]
        public ActionResult ChangePassword() {
            return View();
        }

        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ChangePassword(string currentPassword, string newPassword, string confirmPassword) {
            if (!ValidateChangePassword(currentPassword, newPassword, confirmPassword)) {
                return View();
            }

            try {
                if (MembershipRepository.ChangePassword(base.User.Username, currentPassword, newPassword)) {
                    MembershipRepository.Save();
                    return RedirectToAction("ChangePasswordSuccess");
                } else {
                    ModelState.AddModelError("_FORM", "The current password is incorrect or the new password is invalid.");
                    return View();
                }
            } catch {
                ModelState.AddModelError("_FORM", "The current password is incorrect or the new password is invalid.");
                return View();
            }
        }

        public ActionResult ChangePasswordSuccess() {
            return View();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext) {
            if (filterContext.HttpContext.User.Identity is WindowsIdentity) {
                throw new InvalidOperationException("Windows authentication is not supported.");
            }
        }

        #region Validation Methods

        private bool ValidateChangePassword(string currentPassword, string newPassword, string confirmPassword) {
            if (String.IsNullOrEmpty(currentPassword)) {
                ModelState.AddModelError("currentPassword", "You must specify a current password.");
            }

            if (String.IsNullOrEmpty(newPassword)) {
                ModelState.AddModelError("newPassword", "You must specify a new password.");
            }

            if (!String.Equals(newPassword, confirmPassword, StringComparison.Ordinal)) {
                ModelState.AddModelError("_FORM", "The new password and confirmation password do not match.");
            }

            return ModelState.IsValid;
        }

        private bool ValidateLogOn(string username, string password) {
            if (String.IsNullOrEmpty(username)) {
                ModelState.AddModelError("username", "You must specify a username.");
            }
            if (String.IsNullOrEmpty(password)) {
                ModelState.AddModelError("password", "You must specify a password.");
            }

            IUser user = MembershipRepository.GetUser(username, password);
            if (user == null) {
                ModelState.AddModelError("_FORM", "The username or password provided is incorrect.");
            }

            return ModelState.IsValid;
        }

        private bool ValidateRegistration(string username, string email) {
            if (String.IsNullOrEmpty(username)) {
                ModelState.AddModelError("username", "You must specify a username.");
            }
            if (String.IsNullOrEmpty(email)) {
                ModelState.AddModelError("email", "You must specify an email address.");
            }
            UserAvailability availablility = MembershipRepository.ValidUserRegistration(username, email);
            if (availablility == UserAvailability.DupliacteUsername) {
                ModelState.AddModelError("username", "That username is already taken. Please choose another.");
            }
            if (availablility == UserAvailability.DuplicateEmail) {
                ModelState.AddModelError("email", "That email address is already taken. Please choose another.");
            }

            return ModelState.IsValid;
        }

        #endregion
    }

}
