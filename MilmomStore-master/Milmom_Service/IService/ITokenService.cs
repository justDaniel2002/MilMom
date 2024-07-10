using MilmomStore_BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilmomStore_BusinessObject.IdentityModel;

namespace Milmom_Service.IService
{
    public interface ITokenService
    {
        public Task<TokenModel> createToken(AccountApplication application);
    }
}