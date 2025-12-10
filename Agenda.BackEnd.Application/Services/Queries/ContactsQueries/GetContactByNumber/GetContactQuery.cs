using Agenda.BackEnd.Application.Models;
using Agenda.BackEnd.Application.Models.contactModels;
using MediatR;

namespace Agenda.BackEnd.Application.Services.Queries.ContactQueries.GetContact
{
    public class GetContactQuery:IRequest<ResultViewModel<ContactViewModel>>
    {
        public string PhoneNumber { get; set; }
        public GetContactQuery()
        {
            
        }

        public GetContactQuery(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }
    }
}
