using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Milmom_Service.IService;
using MilmomStore_BusinessObject.IdentityModel;
using MilmomStore_BusinessObject.Model;

namespace MilmomStore.Server.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AccountApplication> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AccountApplication> _signinManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AccountApplication> userManager, ITokenService tokenService,
            SignInManager<AccountApplication> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signinManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());

            if (user == null) return Unauthorized("Invalid username!");

            var result = await _signinManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized("Username not found and/or password incorrect");

            var roles = await _userManager.GetRolesAsync(user);
            var token = await _tokenService.createToken(user);
            return Ok(
                new NewUserDto
                {
                    UserID = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    Roles = roles.ToList(),
                    Phone = user.Phone,
                    Name = user.Name,
                    Address = user.Address,
                    Image = user.Image,
                    Token = token.AccessToken,
                    RefreshToken = token.RefreshToken
                }
            );
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var accountApp = new AccountApplication
                {
                    UserName = registerDto.Username,
                    Name = registerDto.Name,
                    Email = registerDto.Email,
                    Address = registerDto.Address,
                    Phone = registerDto.Phone,
                    Image = registerDto.Image
                };

                var createdUser = await _userManager.CreateAsync(accountApp, registerDto.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(accountApp, "CUSTOMER");
                    var token = await _tokenService.createToken(accountApp);
                    if (roleResult.Succeeded)
                    {
                        var userRoles = await _userManager.GetRolesAsync(accountApp);
                        return Ok(
                            new NewUserDto
                            {
                                UserName = accountApp.UserName,
                                Email = accountApp.Email,
                                Name = accountApp.Name,
                                Address = accountApp.Address,
                                Phone = accountApp.Phone,
                                Image = accountApp.Image,
                                Roles = userRoles.ToList(),
                                Token = token.AccessToken,
                                RefreshToken = token.RefreshToken
                            }
                        );
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("create account")]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountDto createAccountDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (string.IsNullOrEmpty(createAccountDto.Role))
                    return BadRequest("Role is required.");

                var accountApp = new AccountApplication
                {
                    UserName = createAccountDto.Username,
                    Name = createAccountDto.Name,
                    Email = createAccountDto.Email,
                    Address = createAccountDto.Address,
                    Phone = createAccountDto.Phone,
                    Image = createAccountDto.Image
                };

                var createdUser = await _userManager.CreateAsync(accountApp, createAccountDto.Password);

                if (createdUser.Succeeded)
                {
                    var role = createAccountDto.Role.ToUpper();
                    var roleExists = await _roleManager.RoleExistsAsync(role);
                    if (roleExists)
                    {
                        if (createAccountDto.Role.ToUpper() == "ADMIN")
                        {
                            return BadRequest("Cannot create account with role 'Admin'.");
                        }
                        var roleResult = await _userManager.AddToRoleAsync(accountApp, createAccountDto.Role);

                        if (roleResult.Succeeded)
                        {
                            var userRoles = await _userManager.GetRolesAsync(accountApp);
                            var token = await _tokenService.createToken(accountApp);
                            return Ok(
                                new NewUserDto
                                {
                                    UserName = accountApp.UserName,
                                    Email = accountApp.Email,
                                    Name = accountApp.Name,
                                    Address = accountApp.Address,
                                    Phone = accountApp.Phone,
                                    Image = accountApp.Image,
                                    Roles = userRoles.ToList(),
                                    Token = token.AccessToken,
                                    RefreshToken = token.RefreshToken
                                }
                            );
                        }
                        else
                        {
                            return StatusCode(500, roleResult.Errors);
                        }
                    }
                    else
                    {
                        return BadRequest($"Role '{createAccountDto.Role}' does not exist.");
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("Update-Account")]
        public async Task<IActionResult> UpdateAccount( string userId, [FromBody] UpdateAccountDto updateAccountDto)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);

                if (user == null)
                {
                    return NotFound($"User with ID '{userId}' not found.");
                }
                if (!string.IsNullOrEmpty(updateAccountDto.Username))
                {
                    user.UserName = updateAccountDto.Username;
                }

                // Update role if provided
                if (!string.IsNullOrEmpty(updateAccountDto.Role))
                {
                    // Check if the new role exists
                    var newRole = updateAccountDto.Role.ToUpper();
                    var roleExists = await _roleManager.RoleExistsAsync(newRole);
                    if (!roleExists)
                    {
                        return BadRequest($"Role '{newRole}' does not exist.");
                    }

                    // Remove current roles and assign new role
                    var currentRoles = await _userManager.GetRolesAsync(user);
                    var roleRemoveResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);
                    if (!roleRemoveResult.Succeeded)
                    {
                        return StatusCode(500, roleRemoveResult.Errors);
                    }

                    var roleAddResult = await _userManager.AddToRoleAsync(user, newRole);
                    if (!roleAddResult.Succeeded)
                    {
                        return StatusCode(500, roleAddResult.Errors);
                    }
                }

                // Update other account properties
                user.Name = updateAccountDto.Name ?? user.Name;
                user.Address = updateAccountDto.Address ?? user.Address;
                user.Phone = updateAccountDto.Phone ?? user.Phone;
                user.Image = updateAccountDto.Image ?? user.Image;

                // Save changes
                var updateResult = await _userManager.UpdateAsync(user);

                if (updateResult.Succeeded)
                {
                    // Optionally, return updated user information
                    var updatedUserRoles = await _userManager.GetRolesAsync(user);
                    return Ok(new NewUserDto
                    {
                        UserName = user.UserName,
                        Email = user.Email,
                        Name = user.Name,
                        Address = user.Address,
                        Phone = user.Phone,
                        Image = user.Image,
                        Roles = updatedUserRoles.ToList()
                    });
                }
                else
                {
                    return StatusCode(500, updateResult.Errors);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpGet("Get-all-accounts")]
        public async Task<IActionResult> GetAllAccounts()
        {
            try
            {
                // Retrieve all user accounts asynchronously
                var allAccounts = await _userManager.Users.ToListAsync();

                // Map to DTOs for response
                var accountInfoList = allAccounts.Select(user => new NewUserDto
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Name = user.Name,
                    Address = user.Address,
                    Phone = user.Phone,
                    Image = user.Image,
                    Roles = _userManager.GetRolesAsync(user).Result.ToList() // This should ideally be await _userManager.GetRolesAsync(user)
                }).ToList();

                return Ok(accountInfoList);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Failed to retrieve account information: {e.Message}");
            }
        }

        [Authorize(Roles = "Customer")]
        [HttpPost("Reset-Password-Token")]
        public async Task<IActionResult> ResetPasswordToken([FromBody] ResetTokenModel resetTokenModel)
        {
            var user = await _userManager.FindByEmailAsync(resetTokenModel.Email);
            if (user == null)
            {
                return BadRequest("Cannot find Email, Please check again!");
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            return Ok(new { token = token });
        }

        [Authorize(Roles = "Customer")]
        [HttpPost("Reset-Password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetToken resetToken)
        {
            var user = await _userManager.FindByEmailAsync(resetToken.Email);
            if (user == null)
            {
                return BadRequest("UserName is wrong, Please check again!");
            }

            user = await _userManager.FindByNameAsync(resetToken.Username);
            if (user == null)
            {
                return BadRequest("Cannot find Email, Please check again!");
            }

            if (string.Compare(resetToken.Password, resetToken.ConfirmPassword) != 0)
            {
                return BadRequest("Password and ConfirmPassword doesnot match! ");
            }
            if (string.IsNullOrEmpty(resetToken.Token))
            {
                return BadRequest("Invalid Token! ");
            }
            var result = await _userManager.ResetPasswordAsync(user, resetToken.Token, resetToken.Password);
            if (!result.Succeeded)
            {
                var errors = new List<string>();
                foreach (var error in result.Errors)
                {
                    errors.Add(error.Description);
                }
                return StatusCode(500, result.Errors);
            }
            return Ok(new UserDto
            {
                Email = resetToken.Email,
                Username = resetToken.Username,
                Password = resetToken.Password,
                ConfirmPassword = resetToken.ConfirmPassword,
                Token = resetToken.Token,
            });
        }

        [Authorize(Roles = "Admin, Manager, Staff, Customer")]
        [HttpPost("Change-Password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel changePassword)
        {
            var user = await _userManager.FindByNameAsync(changePassword.UserName);
            if(user == null) 
            { 
                return BadRequest("User Not Exist"); 
            }
            if (string.Compare(changePassword.NewPassword, changePassword.ConfirmNewPassword) != 0)
            {
                return BadRequest("Password and ConfirmPassword doesnot match! ");
            }
            var result = await _userManager.ChangePasswordAsync(user, changePassword.CurrentPassword, changePassword.NewPassword);
            if(!result.Succeeded)
            {
                var errors = new List<string>();
                foreach (var error in result.Errors)
                {
                    errors.Add(error.Description);
                }
                return StatusCode(500, result.Errors);
            }
            return Ok(new UserDto
            {
                Username = changePassword.UserName,
                Password = changePassword.NewPassword,
                ConfirmPassword = changePassword.ConfirmNewPassword
            });
        }
    }
}
