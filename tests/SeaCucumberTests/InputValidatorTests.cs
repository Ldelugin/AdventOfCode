using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeaCucumber;

namespace SeaCucumberTests;

[TestClass]
public class InputValidatorTests
{
    [TestMethod]
    public void Validate_ReturnsFalse_WhenInputIsNull()
    {
        // Arrange
        string[]? input = null;
        var inputValidator = new InputValidator(input);
        
        // Act
        var isValid = inputValidator.Validate(out var notValidReason);
        
        // Assert
        Assert.IsFalse(isValid);
        Assert.IsNotNull(notValidReason);
        Assert.IsTrue(notValidReason.Contains("input") && notValidReason.Contains("null"));
    }
    
    [TestMethod]
    public void Validate_ReturnsFalse_WhenInputIsEmpty()
    {
        // Arrange
        var input = Array.Empty<string>();
        var inputValidator = new InputValidator(input);
        
        // Act
        var isValid = inputValidator.Validate(out var notValidReason);
        
        // Assert
        Assert.IsFalse(isValid);
        Assert.IsNotNull(notValidReason);
        Assert.IsTrue(notValidReason.Contains("input") && notValidReason.Contains("empty"));
    }
    
    [TestMethod]
    public void Validate_ReturnsFalse_WhenInputAsInconsistentLinesLength()
    {
        // Arrange
        var input = new[]
        {
            "..>>..",
            "..>.."
        };
        var inputValidator = new InputValidator(input);
        
        // Act
        var isValid = inputValidator.Validate(out var notValidReason);
        
        // Assert
        Assert.IsFalse(isValid);
        Assert.IsNotNull(notValidReason);
        Assert.IsTrue(notValidReason.Contains("Line") && notValidReason.Contains("expected to have a length"));
    }
    
    [TestMethod]
    public void Validate_ReturnsFalse_WhenInputContainCharactersNotExpected()
    {
        // Arrange
        var input = new[]
        {
            "..>>..",
            "..>x.."
        };
        var inputValidator = new InputValidator(input);
        
        // Act
        var isValid = inputValidator.Validate(out var notValidReason);
        
        // Assert
        Assert.IsFalse(isValid);
        Assert.IsNotNull(notValidReason);
        Assert.IsTrue(notValidReason.Contains("Character") && notValidReason.Contains("expected to be"));
    }

    [TestMethod]
    public void Validate_ReturnsTrue_WhenInputIsValid()
    {
        // Arrange
        var input = new[]
        {
            "..>>..",
            "..vv..",
            "v.>v.."
        };
        var inputValidator = new InputValidator(input);
        
        // Act
        var isValid = inputValidator.Validate(out var notValidReason);
        
        // Assert
        Assert.IsTrue(isValid);
        Assert.IsNull(notValidReason);
    }
}