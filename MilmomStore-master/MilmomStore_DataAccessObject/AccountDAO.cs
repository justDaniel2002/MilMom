using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MilmomStore_BusinessObject.Model;
using MilmomStore_DataAccessObject.BaseDAO;

namespace MilmomStore_DataAccessObject
{
    public class AccountDAO : BaseDAO<AccountApplication>
    {
        private readonly MilmomSystemContext _context;
        private readonly UserManager<AccountApplication> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountDAO(MilmomSystemContext context, UserManager<AccountApplication> userManager,
            RoleManager<IdentityRole> roleManager) : base(context)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<(int totalAccount, int staffsAccount, int managersAccount, int customersAccount )> GetTotalAccount()
        {
            var customerRole = await _roleManager.FindByNameAsync("Customer");
            var customersCount = await _userManager.GetUsersInRoleAsync(customerRole.Name);

            var staffRole = await _roleManager.FindByNameAsync("Staff");
            var staffsCount = await _userManager.GetUsersInRoleAsync(staffRole.Name);

            var managerRole = await _roleManager.FindByNameAsync("Manager");
            var managersCount = await _userManager.GetUsersInRoleAsync(managerRole.Name);

            int totalAccountsCount = customersCount.Count + staffsCount.Count + managersCount.Count;
            int staffsAccount = staffsCount.Count;
            int managersAccount = managersCount.Count;
            int customersAccount = customersCount.Count;

            return(totalAccountsCount, staffsAccount, managersAccount, customersAccount);
        }
    }
}
