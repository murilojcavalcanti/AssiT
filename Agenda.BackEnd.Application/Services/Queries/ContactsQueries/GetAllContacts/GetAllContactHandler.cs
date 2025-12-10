using Agenda.BackEnd.Application.Models;
using Agenda.BackEnd.Application.Models.contactModels;
using Agenda.BackEnd.Core.Entities;
using Agenda.BackEnd.Core.Interfaces.Repository;
using AssiT.Application.Models;
using AssiT.Application.Models.AssetModels;
using MediatR;
using System.Linq.Expressions;

namespace Agenda.BackEnd.Application.Services.Queries.ContactQueries.GetContact
{
    public class GetAllContactsHandler : IRequestHandler<GetAllContactQuery, ResultViewModel<List<AssetsViewModel>>>
    {
        private readonly IContactRepository _contactRepository;

        public GetAllContactsHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<ResultViewModel<List<ContactViewModel>>> Handle(GetAllContactQuery request, CancellationToken cancellationToken)
        {

            Expression<Func<Contact, bool>> predicate = c =>
                (request.UserId == 0 || c.UserId == request.UserId) &&
                (string.IsNullOrEmpty(request.Email) || c.EmailAdress.Contains(request.Email)) &&
                (string.IsNullOrEmpty(request.Alias) || c.Alias.Contains(request.Alias)) &&
                (string.IsNullOrEmpty(request.PhoneNumber) || c.PhoneNumber.Contains(request.PhoneNumber));

            var contacts = await _contactRepository.GetAll(predicate, request.Page);

            var contactViewModels = contacts.Select(c => ContactViewModel.FromEntity(c)).ToList();
            return ResultViewModel<List<ContactViewModel>>.Success(contactViewModels);
        }
    }
}
