using AssiT.Application.Models;
using AssiT.Core.Entities;
using AssiT.Core.Interfaces.Repository;
using MediatR;

namespace Agenda.BackEnd.Application.Services.Commands.ContactCommands.CreateContact
{
    public class CreateAssetHandler : IRequestHandler<CreateAssetCommand, ResultViewModel<int>>
    {
        private readonly IAssetRepository _assetRepository;
        private readonly IUserRepository _userRepository;

        public CreateAssetHandler(IAssetRepository assetRepository, IUserRepository userRepository)
        {
            _assetRepository = assetRepository;
            _userRepository = userRepository;
        }

        public async Task<ResultViewModel<int>> Handle(CreateAssetCommand request, CancellationToken cancellationToken)
        {
            Asset asset = request.ToEntity();
            var existingCategory = await _userRepository.Get(u => u.Id == request.CategoryId);
            if (existingCategory == null)
            {
                return ResultViewModel<int>.Error("Não existe esta categoria cadastrada.");
            }
            await _assetRepository.Insert(asset);
            return ResultViewModel<int>.Success(asset.Id);
        }
    }
}
