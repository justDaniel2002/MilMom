using Milmom_Repository.InterfaceRepository;
using MilmomStore_BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Milmom_Service.IService;
using MilmomStore_BusinessObject.IdentityModel;

namespace Milmom_Service.Service
{
    public class TokenService : ITokenService
    {
        private readonly ITokenRepository _tokenRepository;
        public TokenService(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }

        public async Task<TokenModel> createToken(AccountApplication application)
        {
            return await _tokenRepository.createToken(application);
        }
    }
}
