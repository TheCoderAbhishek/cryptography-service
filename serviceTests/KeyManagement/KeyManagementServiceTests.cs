﻿using Bogus;
using Microsoft.Extensions.Logging;
using Moq;
using service.Application.Service.KeyManagement;
using service.Core.Entities.KeyManagement;
using service.Core.Interfaces.KeyManagement;
using service.Core.Interfaces.OpenSsl;

namespace serviceTests.KeyManagement
{
    public class KeyManagementServiceTests
    {
        private readonly Mock<IKeyManagementRepository> _keyManagementRepositoryMock;
        private readonly Mock<ILogger<KeyManagementService>> _loggerMock;
        private readonly KeyManagementService _service;
        private readonly Mock<IOpenSslService> _openSslServiceMock;

        public KeyManagementServiceTests()
        {
            _keyManagementRepositoryMock = new Mock<IKeyManagementRepository>();
            _openSslServiceMock = new Mock<IOpenSslService>();
            _loggerMock = new Mock<ILogger<KeyManagementService>>();
            _service = new KeyManagementService(_loggerMock.Object, _keyManagementRepositoryMock.Object, _openSslServiceMock.Object);
        }

        #region GetKeysList Tests
        [Fact]
        public async Task GetKeysList_ReturnsKeysList_WhenKeysExist()
        {
            // Arrange
            var fakeKeys = new Faker<Keys>()
                .RuleFor(k => k.Id, f => f.Random.Int())
                .RuleFor(k => k.KeyId, f => f.Random.Guid().ToString())
                .RuleFor(k => k.KeyName, f => f.Lorem.Word())
                .Generate(5);

            _keyManagementRepositoryMock.Setup(repo => repo.GetKeysListAsync())
                .ReturnsAsync(fakeKeys);

            // Act
            var (status, keys) = await _service.GetKeysList();

            // Assert
            Assert.Equal(1, status);
            Assert.Equal(5, keys.Count);
        }

        [Fact]
        public async Task GetKeysList_ReturnsNoKeys_WhenEmptyList()
        {
            // Arrange
            _keyManagementRepositoryMock.Setup(repo => repo.GetKeysListAsync())
                .ReturnsAsync([]);

            // Act
            var (status, keys) = await _service.GetKeysList();

            // Assert
            Assert.Equal(0, status);
            Assert.Empty(keys);
        }

        [Fact]
        public async Task GetKeysList_ReturnsError_OnException()
        {
            // Arrange
            _keyManagementRepositoryMock.Setup(repo => repo.GetKeysListAsync())
                .ThrowsAsync(new Exception("Database error"));

            // Act
            var (status, keys) = await _service.GetKeysList();

            // Assert
            Assert.Equal(-1, status);
            Assert.Empty(keys);
        } 
        #endregion
    }
}
