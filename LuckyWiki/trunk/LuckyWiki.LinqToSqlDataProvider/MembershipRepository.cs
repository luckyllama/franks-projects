using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Data.Linq;

namespace LuckyWiki.Data.LinqToSqlDataProvider {
    public class MembershipRepository : IMembershipRepository {

        private LuckyWikiDataContext dataContext;

        internal MembershipRepository(LuckyWikiDataContext dataContext) {
            this.dataContext = dataContext;
        }

        #region IMembershipRepository Members

        public IUser GetUser(int id) {
            return dataContext.Users.SingleOrDefault(u => u.Id == id);
        }

        public IUser GetUser(string username) {
            return dataContext.Users.SingleOrDefault(u => u.Username == username);
        }

        public IUser GetUser(string username, string password) {
            IUser user = dataContext.Users.SingleOrDefault(u => u.Username == username);
            if (user == null)  {
                return null;
            }

            string passwordSalt = user.PasswordSalt;

            string hashedPassword = hashPassword(password, passwordSalt);

            return dataContext.Users.SingleOrDefault(u => u.Username == username && u.Password == hashedPassword);
        }

        public IUser GetAnonymousUser(string username) {
            IUser anonymousUser = GetUser(username);

            // create a new user if one doesn't exist
            if (anonymousUser == null) {
                anonymousUser = CreateUser();
                anonymousUser.Username = username;
                anonymousUser.DisplayName = "Anonymous User";
                anonymousUser.Status = UserStatus.Normal;
                anonymousUser.IsAnonymous = true;

                RegisterAnonymousUser(anonymousUser);
                Save();

                anonymousUser = GetUser(username);
            }

            return anonymousUser;
        }

        public bool ContainsUser(string username) {
            return (GetUser(username) != null);
        }

        public IUser CreateUser() {
            return new User();
        }

        public UserAvailability ValidUserRegistration(string username, string email) { 
            IUser user = dataContext.Users.SingleOrDefault(u => u.Username == username || u.Email == email);
            if (user == null) {
                return UserAvailability.Available;
            }
            if (user.Username == username) {
                return UserAvailability.DupliacteUsername;
            } else if (user.Email == email) {
                return UserAvailability.DuplicateEmail;
            } else {
                return UserAvailability.Available;
            }
        }

        public void RegisterAnonymousUser(IUser user) {
            user.Status = UserStatus.Normal;
            user.IsAnonymous = true;
            RegisterUser(user, null);
        }

        public void RegisterUser(IUser user, string password) {
            if (string.IsNullOrEmpty(user.Username)) {
                throw new ArgumentNullException("user.Username");
            }

            if (!string.IsNullOrEmpty(password)) {
                user.PasswordSalt = generateSalt();
                user.Password = hashPassword(password, user.PasswordSalt);
            }

            dataContext.Users.InsertOnSubmit((User)user);
        }

        public bool ChangePassword(string username, string password, string newPassword) {
            IUser user = GetUser(username, password);

            if (user != null) {
                user.PasswordSalt = generateSalt();
                user.Password = hashPassword(password, user.PasswordSalt);
                return true;
            }

            return false;
        }

        public void Save() {
            dataContext.SubmitChanges(ConflictMode.FailOnFirstConflict);
        }

        #endregion IMembershipRepository Members

        #region Hashing Methods

        private static string hashPassword(string rawString, string salt) {
            byte[] salted = Encoding.UTF8.GetBytes(string.Concat(rawString, salt));

            SHA256 hasher = new SHA256Managed();
            byte[] hashed = hasher.ComputeHash(salted);

            return Convert.ToBase64String(hashed);
        }

        private static string generateSalt() {
            int minSaltSize = 4;
            int maxSaltSize = 8;

            Random random = new Random();
            int saltSize = random.Next(minSaltSize, maxSaltSize);

            byte[] saltBytes = new byte[saltSize];

            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetNonZeroBytes(saltBytes);

            return Convert.ToBase64String(saltBytes);
        }

        #endregion Hashing Methods
    }
}
