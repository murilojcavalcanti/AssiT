using AssiT.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssiT.Application.Services.Queries.WhatsAppQueries
{
    public class WhaQuery : IRequest<ResultViewModel<string>>
    {
        public string accessToken { get; set; }
        public string phoneNumberId { get; set; }
        public string recipient { get; set; }
        public string message { get; set; }
    }
}
