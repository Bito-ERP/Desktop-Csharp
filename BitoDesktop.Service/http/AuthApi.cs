using BitoDesktop.Service.DTOs.Auth;
using BitoDesktop.Service.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitoDesktop.Service.http;

internal class AuthApi
{

    public static async Task<BaseResponse<List<UsernameResponse>>> GetUsernames(RequestLogin request) =>
       await Client.Post<List<UsernameResponse>>("employee/v3/get-usernames", request);

    public static async Task<BaseResponse<String>> Login(RequestLogin request) =>
       await Client.Post<String>("employee/v2/login", request);

    public static async Task ForgotPassword(RequestLogin request) =>
       await Client.Post("employee/forgot-password", request);

    public static async Task<BaseResponse<String>> ResetPassword(RequestResetPassword request) =>
         await Client.Post<String>("employee/reset-password", request);

    public static async Task Logout() =>
        await Client.Post("employee/logout", null);

    public static async Task Verify(RequestConfirm request) =>
         await Client.Post("employee/verify-reset-otp", request);

}

