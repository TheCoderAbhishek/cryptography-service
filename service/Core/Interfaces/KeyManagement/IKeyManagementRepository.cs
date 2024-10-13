﻿using service.Core.Entities.KeyManagement;

namespace service.Core.Interfaces.KeyManagement
{
    /// <summary>
    /// Defines the interface for interacting with key management data.
    /// </summary>
    public interface IKeyManagementRepository
    {
        /// <summary>
        /// Asynchronously retrieves a list of keys.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, returning a list of keys.</returns>
        Task<List<Keys>> GetKeysListAsync();

        /// <summary>
        /// Creates a new key asynchronously.
        /// </summary>
        /// <param name="key">The key to create.</param>
        /// <returns>A task that represents the asynchronous operation. The task result is the newly created key ID.</returns>
        Task<int> CreateKeyAsync(Keys key);

        /// <summary>
        /// Checks if a given key name is unique within the system.
        /// </summary>
        /// <param name="keyName">The key name to be checked.</param>
        /// <returns>A task that returns 1 if the key name is unique, 0 if it is not unique, and throws an exception if there is an error.</returns>
        Task<int> CheckUniqueKeyName(string keyName);

        /// <summary>
        /// Inserts a new record into the `tblSecureKeys` table asynchronously.
        /// </summary>
        /// <param name="secureKeys">An object containing the key information to be inserted.</param>
        /// <returns>A task representing the operation. The result of the task will be the number of rows affected by the insertion.</returns>
        Task<int> InsertPrivateDataAsync(SecureKeys secureKeys);

        /// <summary>
        /// Checks if a given key id is unique within the system.
        /// </summary>
        /// <param name="keyId">The key id to be checked.</param>
        /// <returns>A task that returns 1 if the key id is unique, 0 if it is not unique, and throws an exception if there is an error.</returns>
        Task<int> CheckUniqueKeyIdAsync(string keyId);

        /// <summary>
        /// Gets the key data from table.
        /// </summary>
        /// <param name="id">The integer id associated with key.</param>
        /// <returns>A string of key data.</returns>
        Task<string> ExportKeyAsync(int id);

        /// <summary>
        /// Retrieves key details based on the provided ID.
        /// </summary>
        /// <param name="id">The ID of the key to retrieve.</param>
        /// <returns>A Task that represents the asynchronous operation. The result of the task will be a Keys object containing the requested key details.</returns>
        Task<Keys?> GetKeyDetailsByIdAsync(int id);
    }
}
