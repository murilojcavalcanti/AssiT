using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AssiT.Core.Entities
{
    public class User: BaseEntity
    {
        public User(string email, string name, string password): base(DateTime.Now)
        {
            Email = email;
            Name = name;
            Password = password;
        }
        public User(string email, string name) : base(DateTime.Now)
        {
            Email = email;
            Name = name;
        }

        [EmailAddress]
        public string Email { get; set; }
        [MinLength(3)]
        public string Name { get; set; }
        [Length(8,16)]
        public string Password { get; set; }

        public void Update(User userUpdated)
        {
            Email = string.IsNullOrEmpty(userUpdated.Email) ? Email : userUpdated.Email;
            Name  = string.IsNullOrEmpty(userUpdated.Name) ? Name : userUpdated.Name;
        }
        public void UpdatePassWord(User userUpdated)
        {
            Password = string.IsNullOrEmpty(userUpdated.Password) ? Password : userUpdated.Password;
        }
    }
}
