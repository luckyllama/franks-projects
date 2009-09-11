using System;
namespace LuckyWiki.Data {

    public interface IUser {
        int Id { get; set; }
        string Username { get; set; }
        string DisplayName { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        string PasswordSalt { get; set; }
        UserStatus Status { get; set; }
        bool IsAnonymous { get; set; }
        DateTime RegistrationDate { get; set; }
    }

}
