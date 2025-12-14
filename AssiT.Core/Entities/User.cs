using AssiT.Core.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AssiT.Core.Entities
{
    public class User: BaseEntity
    {
        public User(string email, string name, string password, perfilEnum perfil) : base(DateTime.Now)
        {
            Email = email;
            Name = name;
            Password = password;
            Perfil = perfil;
        }
        public User(string email, string name) : base(DateTime.Now)
        {
            Email = email;
            Name = name;
        }

        [EmailAddress]
        [StringLength(100,MinimumLength =3,ErrorMessage = "O nome deve ter no maximo 100 caracteres e no minimo 3 caracteres")]
        public string Email { get; set; }
        [StringLength(100,MinimumLength =3,ErrorMessage = "O nome deve ter no maximo 100 caracteres e no minimo 3 caracteres")]
        public string Name { get; set; }
        [Length(8,100)]
        public string Password { get; set; }

        public perfilEnum Perfil { get; set; }

        public void Update(User userUpdated)
        {
            Email = string.IsNullOrEmpty(userUpdated.Email) ? Email : userUpdated.Email;
            Name  = string.IsNullOrEmpty(userUpdated.Name) ? Name : userUpdated.Name;
            Perfil = (int)userUpdated.Perfil == 0 || userUpdated.Perfil ==null
                ? Perfil : userUpdated.Perfil;
        }
        public void UpdatePassWord(User userUpdated)
        {
            Password = string.IsNullOrEmpty(userUpdated.Password) ? Password : userUpdated.Password;
        }
    }
}
