﻿using MixMeal.Modules.UserManagement;
using Xunit;

namespace MixMeal.Web.UnitTests.Modules.UserManagement.Security;

public class HmacSha512PasswordStorageFixture
{
    [Fact]
    public void Create_AreNotEqual_WithDifferentSalt()
    {
        // Arrange
        var passwordStorage = new HmacSha512PasswordStorage();

        // Act
        string hash1 = passwordStorage.Create("test");
        string hash2 = passwordStorage.Create("test");

        // Assert
        Assert.NotEqual(hash1, hash2);
    }

    [Fact]
    public void Create_Match_OkWithWithSame()
    {
        // Arrange
        var passwordStorage = new HmacSha512PasswordStorage();

        // Act
        string hash = passwordStorage.Create("test");
        bool ok = passwordStorage.Match("test", hash);

        // Assert
        Assert.True(ok);
    }
}