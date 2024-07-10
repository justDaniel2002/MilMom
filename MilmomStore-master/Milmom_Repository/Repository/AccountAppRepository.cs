using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Milmom_Repository.BaseRepository;
using Milmom_Repository.IRepository;
using MilmomStore_BusinessObject.Model;
using MilmomStore_DataAccessObject;

namespace Milmom_Repository.Repository
{
    public class AccountAppRepository : BaseRepository<AccountApplication>,IAccountAppRepository
    {
        private readonly AccountDAO _accountDao;
        

        public AccountAppRepository(AccountDAO accountDao) : base(accountDao)
        {
            _accountDao = accountDao;
        }

        public async Task<IEnumerable<AccountApplication>> GetAllAsync()
        {
            return await _accountDao.GetAllAsync();
        }

        public async Task<AccountApplication> GetByIdAsync(int id)
        {
            return await _accountDao.GetByIdAsync(id);
        }

        public async Task<AccountApplication> GetByStringIdAsync(string id)
        {
            return await _accountDao.GetByStringIdAsync(id);
        }

        public async Task<AccountApplication> AddAsync(AccountApplication entity)
        {
            return await _accountDao.AddAsync(entity);
        }

        public async Task<AccountApplication> UpdateAsync(AccountApplication entity)
        {
            return await _accountDao.UpdateAsync(entity);
        }

        public async Task<AccountApplication> DeleteAsync(AccountApplication entity)
        {
            return await _accountDao.DeleteAsync(entity);
        }

        public async Task<(int totalAccount, int staffsAccount, int managersAccount, int customersAccount)> GetTotalAccount()
        {
            return await _accountDao.GetTotalAccount();
        }
    }
}
