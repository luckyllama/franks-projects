using System;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LuckyWiki;
using LuckyWiki.Data;
using LuckyWiki.Web.Controllers;
using LuckyWiki.Authentication;

namespace LuckyWiki.Tests.Controllers {

    [TestClass]
    public class AccountControllerTest {

        [TestMethod]
        public void ChangePasswordGetReturnsView() {
            // Arrange
            AccountController controller = GetAccountController();

            // Act
            ViewResult result = (ViewResult)controller.ChangePassword();

            // Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual(6, result.ViewData["PasswordLength"]);
        }

        [TestMethod]
        public void ChangePasswordPostRedirectsOnSuccess() {
            // Arrange
            AccountController controller = GetAccountController();

            // Act
            RedirectToRouteResult result = (RedirectToRouteResult)controller.ChangePassword("oldPass", "newPass", "newPass");

            // Assert
            Assert.AreEqual("ChangePasswordSuccess", result.RouteValues["action"]);
        }

        [TestMethod]
        public void ChangePasswordPostReturnsViewIfCurrentPasswordNotSpecified() {
            // Arrange
            AccountController controller = GetAccountController();

            // Act
            ViewResult result = (ViewResult)controller.ChangePassword("", "newPassword", "newPassword");

            // Assert
            //Assert.AreEqual(6, result.ViewData["PasswordLength"]);
            Assert.AreEqual("You must specify a current password.", result.ViewData.ModelState["currentPassword"].Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void ChangePasswordPostReturnsViewIfNewPasswordDoesNotMatchConfirmPassword() {
            // Arrange
            AccountController controller = GetAccountController();

            // Act
            ViewResult result = (ViewResult)controller.ChangePassword("currentPassword", "newPassword", "otherPassword");

            // Assert
            //Assert.AreEqual(6, result.ViewData["PasswordLength"]);
            Assert.AreEqual("The new password and confirmation password do not match.", result.ViewData.ModelState["_FORM"].Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void ChangePasswordPostReturnsViewIfNewPasswordIsNull() {
            // Arrange
            AccountController controller = GetAccountController();

            // Act
            ViewResult result = (ViewResult)controller.ChangePassword("currentPassword", null, null);

            // Assert
            //Assert.AreEqual(6, result.ViewData["PasswordLength"]);
            Assert.AreEqual("You must specify a new password.", result.ViewData.ModelState["newPassword"].Errors[0].ErrorMessage);
        }

        //[TestMethod]
        //public void ChangePasswordPostReturnsViewIfNewPasswordIsTooShort() {
        //    // Arrange
        //    AccountController controller = GetAccountController();

        //    // Act
        //    ViewResult result = (ViewResult)controller.ChangePassword("currentPassword", "12345", "12345");

        //    // Assert
        //    Assert.AreEqual(6, result.ViewData["PasswordLength"]);
        //    Assert.AreEqual("You must specify a new password of 6 or more characters.", result.ViewData.ModelState["newPassword"].Errors[0].ErrorMessage);
        //}

        [TestMethod]
        public void ChangePasswordPostReturnsViewIfProviderRejectsPassword() {
            // Arrange
            AccountController controller = GetAccountController();

            // Act
            ViewResult result = (ViewResult)controller.ChangePassword("oldPass", "badPass", "badPass");

            // Assert
            //Assert.AreEqual(6, result.ViewData["PasswordLength"]);
            Assert.AreEqual("The current password is incorrect or the new password is invalid.", result.ViewData.ModelState["_FORM"].Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void ChangePasswordSuccess() {
            // Arrange
            AccountController controller = GetAccountController();

            // Act
            ViewResult result = (ViewResult)controller.ChangePasswordSuccess();

            // Assert
            Assert.IsNotNull(result);
        }

        //[TestMethod]
        //public void ConstructorSetsProperties() {
        //    // Arrange
        //    IFormsAuthentication formsAuth = new MockFormsAuthenticationService();
        //    IMembershipService membershipService = new AccountMembershipService();

        //    // Act
        //    AccountController controller = new AccountController(formsAuth, membershipService);

        //    // Assert
        //    Assert.AreEqual(formsAuth, controller.FormsAuth, "FormsAuth property did not match.");
        //    Assert.AreEqual(membershipService, controller.MembershipService, "MembershipService property did not match.");
        //}

        //[TestMethod]
        //public void ConstructorSetsPropertiesToDefaultValues() {
        //    // Act
        //    AccountController controller = new AccountController();

        //    // Assert
        //    Assert.IsNotNull(controller.FormsAuth, "FormsAuth property is null.");
        //    Assert.IsNotNull(controller.MembershipService, "MembershipService property is null.");
        //}

        [TestMethod]
        public void LoginGet() {
            // Arrange
            AccountController controller = GetAccountController();

            // Act
            ViewResult result = (ViewResult)controller.Login();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void LoginPostRedirectsHomeIfLoginSuccessfulButNoReturnUrlGiven() {
            // Arrange
            AccountController controller = GetAccountController();

            // Act
            RedirectToRouteResult result = (RedirectToRouteResult)controller.Login("someUser", "goodPass", true, null);

            // Assert
            Assert.AreEqual("Home", result.RouteValues["controller"]);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void LoginPostRedirectsToReturnUrlIfLoginSuccessfulAndReturnUrlGiven() {
            // Arrange
            AccountController controller = GetAccountController();

            // Act
            RedirectResult result = (RedirectResult)controller.Login("someUser", "goodPass", false, "someUrl");

            // Assert
            Assert.AreEqual("someUrl", result.Url);
        }

        [TestMethod]
        public void LoginPostReturnsViewIfPasswordNotSpecified() {
            // Arrange
            AccountController controller = GetAccountController();

            // Act
            ViewResult result = (ViewResult)controller.Login("username", "", true, null);

            // Assert
            Assert.AreEqual("You must specify a password.", result.ViewData.ModelState["password"].Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void LoginPostReturnsViewIfUsernameNotSpecified() {
            // Arrange
            AccountController controller = GetAccountController();

            // Act
            ViewResult result = (ViewResult)controller.Login("", "somePass", false, null);

            // Assert
            Assert.AreEqual("You must specify a username.", result.ViewData.ModelState["username"].Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void LoginPostReturnsViewIfUsernameOrPasswordIsIncorrect() {
            // Arrange
            AccountController controller = GetAccountController();

            // Act
            ViewResult result = (ViewResult)controller.Login("someUser", "badPass", true, null);

            // Assert
            Assert.AreEqual("The username or password provided is incorrect.", result.ViewData.ModelState["_FORM"].Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void LogOff() {
            // Arrange
            AccountController controller = GetAccountController();

            // Act
            RedirectToRouteResult result = (RedirectToRouteResult)controller.LogOut();

            // Assert
            Assert.AreEqual("Home", result.RouteValues["controller"]);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void RegisterGet() {
            // Arrange
            AccountController controller = GetAccountController();

            // Act
            ViewResult result = (ViewResult)controller.Register();

            // Assert
            //Assert.AreEqual(6, result.ViewData["PasswordLength"]);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void RegisterPostRedirectsHomeIfRegistrationSuccessful() {
            // Arrange
            AccountController controller = GetAccountController();

            // Act
            RedirectToRouteResult result = (RedirectToRouteResult)controller.Register("someUser", "email");

            // Assert
            Assert.AreEqual("Home", result.RouteValues["controller"]);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void RegisterPostReturnsViewIfEmailNotSpecified() {
            // Arrange
            AccountController controller = GetAccountController();

            // Act
            ViewResult result = (ViewResult)controller.Register("username", "");

            // Assert
            //Assert.AreEqual(6, result.ViewData["PasswordLength"]);
            Assert.AreEqual("You must specify an email address.", result.ViewData.ModelState["email"].Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void RegisterPostReturnsViewIfRegistrationFails() {
            // Arrange
            AccountController controller = GetAccountController();

            // Act
            ViewResult result = (ViewResult)controller.Register("someUser", "DuplicateUserName" /* error */);

            // Assert
            //Assert.AreEqual(6, result.ViewData["PasswordLength"]);
            Assert.AreEqual("That username is already taken. Please choose another.", result.ViewData.ModelState["username"].Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void RegisterPostReturnsViewIfUsernameNotSpecified() {
            // Arrange
            AccountController controller = GetAccountController();

            // Act
            ViewResult result = (ViewResult)controller.Register("", "email");

            // Assert
            //Assert.AreEqual(6, result.ViewData["PasswordLength"]);
            Assert.AreEqual("You must specify a username.", result.ViewData.ModelState["username"].Errors[0].ErrorMessage);
        }

        private static AccountController GetAccountController() {
            IFormsAuthentication forms = new MockFormsAuthenticationService();
            IMembershipRepository membership = new MockMembershipRepository();
            //MembershipProvider membershipProvider = new MockMembershipProvider();
            //AccountMembershipService membershipService = new AccountMembershipService(membershipProvider);
            AccountController controller = new AccountController(membership, forms);
            ControllerContext controllerContext = new ControllerContext(new MockHttpContext(), new RouteData(), controller);
            controller.ControllerContext = controllerContext;
            return controller;
        }

        public class MockFormsAuthenticationService : IFormsAuthentication {
            public void SignIn(string userName, bool createPersistentCookie) { }
            public void SignOut() { }
        }

        public class MockIdentity : IIdentity {
            public string AuthenticationType {
                get {
                    return "MockAuthentication";
                }
            }

            public bool IsAuthenticated {
                get {
                    return true;
                }
            }

            public string Name {
                get {
                    return "someUser";
                }
            }
        }

        public class MockPrincipal : IPrincipal {
            IIdentity _identity;

            public IIdentity Identity {
                get {
                    if (_identity == null) {
                        _identity = new MockIdentity();
                    }
                    return _identity;
                }
            }

            public bool IsInRole(string role) {
                return false;
            }
        }

        public class MockHttpContext : HttpContextBase {
            private IPrincipal _user;

            public override IPrincipal User {
                get {
                    if (_user == null) {
                        _user = new MockPrincipal();
                    }
                    return _user;
                }
                set {
                    _user = value;
                }
            }
        }

        public class MockMembershipRepository : IMembershipRepository {

            private IUser user = new MockUser { Username = "someUser", Password = "goodPass" };

            #region IMembershipRepository Members

            public IUser GetUser(int id) {
                throw new NotImplementedException();
            }

            public IUser GetUser(string username) {
                return username == user.Username ? user : null;
            }

            public IUser GetUser(string username, string password) {
                return (username == user.Username && password == user.Password) ? user : null;
            }

            public IUser GetAnonymousUser(string username) {
                throw new NotImplementedException();
            }

            public bool ContainsUser(string username) {
                return username == user.Username;
            }

            public IUser CreateUser() {
                throw new NotImplementedException();
            }

            public UserAvailability ValidUserRegistration(string username, string email) {
                if (username == user.Username) 
                    return UserAvailability.DupliacteUsername;
                return UserAvailability.Available;
            }

            public void RegisterAnonymousUser(IUser user) { 
            
            }

            public void RegisterUser(IUser user, string password) {
                
            }

            public bool ChangePassword(string username, string password, string newPassword) {
                return (username == user.Username && password == user.Password) ? true : false;
            }

            public void Save() {
                throw new NotImplementedException();
            }

            #endregion

        }

        public class MockUser : IUser {

            #region IUser Members

            public int Id { get; set; }

            public string Username { get; set; }

            public string DisplayName { get; set; }

            public string Email { get; set; }

            public string Password { get; set; }

            public string PasswordSalt { get; set; }

            public UserStatus Status { get; set; }

            public bool IsAnonymous { get; set; }

            public DateTime RegistrationDate { get; set; }

            #endregion
        }
    }
}
