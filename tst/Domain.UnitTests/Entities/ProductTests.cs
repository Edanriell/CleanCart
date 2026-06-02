using System.Reflection;
using Domain.Entities;

namespace Domain.UnitTests.Entities;

public class ProductTests
{
    [Fact]
    public void Product_Properties_HavePrivateSetters()
    {
        // Arrange
        var productType = typeof(Product);

        // Act
        var properties = productType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        // Assert
        Assert.True(properties.All(p => p.GetSetMethod() == null));
    }
}