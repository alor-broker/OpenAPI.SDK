using Alor.OpenAPI.DI;

namespace Alor.OpenAPI.Tests;

public class OpenApiClientOptionsTests
{
    [Fact]
    public void Validate_Throws_If_CustomConfig_Missing_Required()
    {
        var options = new OpenApiClientOptions
        {
            RefreshToken = "token",
            UseCustomConfig = true,
            BaseUrl = null
        };
        Assert.Throws<InvalidOperationException>(() => options.Validate());
    }

    [Fact]
    public void Validate_Throws_If_Contour_Invalid()
    {
        var options = new OpenApiClientOptions
        {
            RefreshToken = "token",
            Contour = "BadContour"
        };
        Assert.Throws<InvalidOperationException>(() => options.Validate());
    }

    [Fact]
    public void Validate_DoesNotThrow_If_Config_Valid()
    {
        var options = new OpenApiClientOptions
        {
            RefreshToken = "token",
            Contour = "Prod"
        };
        options.Validate();
    }
}