using Agenda.BackEnd.Application.Models;
using Agenda.BackEnd.Application.Models.contactModels;
using Agenda.BackEnd.Core.Entities;
using Agenda.BackEnd.Core.Interfaces.Repository;
using MediatR;

namespace Agenda.BackEnd.Application.Services.Queries.ContactQueries.GetContact
{
    public class GetContactHandler : IRequestHandler<GetContactQuery,ResultViewModel<ContactViewModel>>
    {
        private readonly IContactRepository _contactRepository;

        public GetContactHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<ResultViewModel<ContactViewModel>> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            Contact? contact = await _contactRepository.Get(c=>c.PhoneNumber==request.PhoneNumber);

            return ResultViewModel<ContactViewModel>.Success(ContactViewModel.FromEntity(contact));
        }
    }
}
