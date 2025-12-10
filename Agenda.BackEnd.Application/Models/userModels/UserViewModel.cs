
namespace AssiT.Application.Models.userModels
{
    public class UserViewModel
    {
        public UserViewModel(string email, string name, ICollection<ContactViewModel>? contacts, int id)
        {
            Email = email;
            Name = name;
            Contacts = contacts;
            Id = id;
        }
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public ICollection<ContactViewModel>? Contacts { get; set; }

        public static UserViewModel FromEntity(User user) =>
            new UserViewModel(
                email: user.Email,
                name: user.Name,
                contacts: user.Contacts == null? new List<ContactViewModel>() : user.Contacts.Select(contact => ContactViewModel.FromEntity(contact)).ToList(),
                id:user.Id
             );
    }
}
