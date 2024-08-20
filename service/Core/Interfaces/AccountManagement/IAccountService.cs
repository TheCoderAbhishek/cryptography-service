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
        /// Asynchronously attempts to login a client using the provided credentials.
        /// </summary>
        /// <param name="inLoginUserDto">A DTO containing login credentials.</param>
        /// <returns>A Task that resolves to a User object containing user information on success, or null on failure.</returns>
        Task<(int, string, User?)> LoginUser(InLoginUserDto inLoginUserDto);

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

        /// <summary>
        /// Verifies the provided OTP (One-Time Password).
        /// </summary>
        /// <param name="inVerifyOtpDto">The data transfer object containing the email and OTP to be verified.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a BaseResponse indicating the success or failure of the verification.</returns>
        Task<BaseResponse> VerifyOtp(InVerifyOtpDto inVerifyOtpDto);

        /// <summary>
        /// Soft deletes a user associated with the provided email address.
        /// </summary>
        /// <param name="email">The email address of the user to soft delete.</param>
        /// <returns>A Task that represents the asynchronous operation and returns a BaseResponse indicating the success or failure of the operation.</returns>
        Task<BaseResponse> SoftDeleteUser(string email);
    }
}
