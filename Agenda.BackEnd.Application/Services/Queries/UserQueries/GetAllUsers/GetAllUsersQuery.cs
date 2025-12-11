using AssiT.BackEnd.Application.Models;
using AssiT.BackEnd.Application.Models.contactModels;
using AssiT.BackEnd.Application.Models.userModels;
using MediatR;
using System.ComponentModel;

namespace AssiT.BackEnd.Application.Services.Queries.UserQueries.GetAllUsers
{
    public class GetAllUsersQuery:IRequest<ResultViewModel<List<UserViewModel>>>
    {
        [DefaultValue(1)]
        public int Page { get; set; }

        public GetAllUsersQuery(int page)
        {
            Page = page;
        }
        public GetAllUsersQuery()
        {
            
        }
    }
}
