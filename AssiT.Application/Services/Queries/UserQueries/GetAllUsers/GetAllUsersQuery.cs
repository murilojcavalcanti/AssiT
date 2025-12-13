using AssiT.Application.Models;
using AssiT.Application.Models.userModels;
using MediatR;
using System.ComponentModel;

namespace AssiT.BackEnd.Application.Services.Queries.UserQueries.GetAllUsers
{
    public class GetAllUsersQuery:IRequest<ResultViewModel<(List<UserViewModel>, int)>>
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
