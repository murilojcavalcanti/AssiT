using AssiT.Application.Models;
using AssiT.Application.Models.AssetModels;
using MediatR;
using System.ComponentModel;

namespace Agenda.BackEnd.Application.Services.Queries.ContactQueries.GetContact
{
    public class GetAllContactQuery:IRequest<ResultViewModel<List<AssetsViewModel>>>
    {
        public int UserId { get; set; }
        [DefaultValue("")]
        public string? Email { get; set; }
        [DefaultValue("")]
        public string? Alias { get; set; }
        [DefaultValue("")]
        public string? PhoneNumber { get; set; }

        [DefaultValue(1)]
        public int Page { get; set; }
        public GetAllContactQuery()
        {
            
        }

        public GetAllContactQuery(int userId, string email, string alias, int page, string phoneNumber)
        {
            UserId = userId;
            Email = email;
            Alias = alias;
            Page = page;
            PhoneNumber = phoneNumber;
        }
    }
}
