using AssiT.Application.Models;
using AssiT.Application.Models.userModels;
using MediatR;

namespace AssiT.BackEnd.Application.Services.Queries.UserQueries.GetUserById
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
