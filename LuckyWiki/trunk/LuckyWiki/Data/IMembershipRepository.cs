using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LuckyWiki.Data {

    public interface IMembershipRepository {
        IUser GetUser(int id);
        IUser GetUser(string username);
        IUser GetUser(string username, string password);

        bool ContainsUser(string username);

        IUser GetAnonymousUser(string username);
        
        IUser CreateUser();
        UserAvailability ValidUserRegistration(string username, string email);
        void RegisterUser(IUser user, string password);

        /// <summary>
        /// If the username and password supplied are valid, set the new password for the user. 
        /// </summary>
        /// <param name="username">the users username</param>
        /// <param name="password">the users current password</param>
        /// <param name="newPassword">the new password</param>
        /// <returns>whether the users password will be changed</returns>
        bool ChangePassword(string username, string password, string newPassword);

        void Save();

    }

    public enum UserAvailability { 
        Available,
        DuplicateEmail,
        DupliacteUsername
    }

}
