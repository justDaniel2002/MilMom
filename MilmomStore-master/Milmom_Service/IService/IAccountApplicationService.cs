using System.Collections;
using MilmomStore_BusinessObject.Model;
using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Request.AccountApplication;
using Milmom_Service.Model.Response.AccountApplication;
using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Request.AccountApplication;
using Milmom_Service.Model.Response.AccountApplication;

namespace Milmom_Service.IService;

public interface IAccountApplicationService
{
    //Task<BaseResponse<IEnumerable<GetAllUserResponse>>> GetAllUser();
    Task<BaseResponse<IEnumerable<GetAllUserResponse>>> GetAllUserFromBase();
    //Task<BaseResponse<GetUserByIdResponse>> GetUserById(int id);
    Task<BaseResponse<GetUserByIdResponse>> GetUserByIdFromBase(int id);
    //Task<BaseResponse<UpdateUserResponse>> UpdateUser(int id, UpdateUserRequest user);
    Task<BaseResponse<UpdateUserResponse>> UpdateUserFromBase(int id, UpdateUserRequest user);
    //Task<BaseResponse<DeleteUserResponse>> DeleteUser(int id);
    Task<BaseResponse<DeleteUserResponse>> DeleteUserFromBase(int id);
    //Task<BaseResponse<CreateNewUserResponse>> CreateUser(CreateNewUserRequest request);
    Task<BaseResponse<CreateNewUserResponse>> CreateUserFromBase(CreateNewUserRequest request);
    Task<BaseResponse<GetUserByStringIdResponse>> GetUserByStringIdFromBase(string id);
    Task<BaseResponse<UpdateUserResponseByString>> UpdateUserByStringFromBase(string id, UpdateUserRequestByString user);
    Task<BaseResponse<GetTotalAccounts>> GetTotalAccounts();
}