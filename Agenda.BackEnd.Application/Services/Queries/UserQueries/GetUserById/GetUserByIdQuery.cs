using Agenda.BackEnd.Application.Models;
using Agenda.BackEnd.Application.Models.userModels;
using MediatR;

namespace Agenda.BackEnd.Application.Services.Queries.UserQueries.GetUserById
{
    public class GetUserByIdQuery:IRequest<ResultViewModel<UserViewModel>>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
        public GetUserByIdQuery()
        {
            
        }
    }
}
