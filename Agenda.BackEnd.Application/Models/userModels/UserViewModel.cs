using AssiT.Core.Entities;

namespace AssiT.Application.Models.userModels
{
    public class UserViewModel
    {
        public UserViewModel(string email, string name, int id)
        {
            Email = email;
            Name = name;
            Id = id;
        }
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        
        public static UserViewModel FromEntity(User user) =>
            new UserViewModel(
                email: user.Email,
                name: user.Name,
                id:user.Id
             );
    }
}
