﻿using service.Core.Dto.AccountManagement;
using service.Core.Entities.AccountManagement;
using service.Core.Entities.Utility;

namespace service.Core.Interfaces.AccountManagement
{
    /// <summary>
    /// Defines the contract for a service that manages user accounts.
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Asynchronously adds a new user to the system and returns the user ID and a status code.
        /// </summary>
        /// <param name="inAddUserDto">The user data object containing information for the new user.</param>
        /// <returns>A task representing the asynchronous operation. The task result is a tuple containing the ID of the newly added user and a status code.</returns>
        Task<(int, int)> AddNewUser(InAddUserDto inAddUserDto);

        /// <summary>
        /// Retrieves a list of all users and the total count of users.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a tuple with the total count of users as the first element and a list of users as the second element.</returns>
        Task<(int, List<User>)> GetAllUsers();

        /// <summary>
        /// Generates a One-Time Password (OTP) based on the provided request data.
        /// </summary>
        /// <param name="inOtpRequestDto">The input data transfer object containing the necessary information for OTP generation.</param>
        /// <returns>An asynchronous task that returns an integer representing the status of the OTP generation process.</returns>
        Task<BaseResponse> OtpGeneration(InOtpRequestDto inOtpRequestDto);
    }
}
