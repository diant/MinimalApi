using FluentAssertions;
using MinimalApi.Modules.Hello;

namespace HelloTest;

public class HelloValidatorTests
{
    [Fact]
    public void HelloValidatorWithoutNameReturnsTrue()
    {
        var helloValidator = new HelloRequestValidator();
        var request = new HelloRequest("");
        var result = helloValidator.Validate(request);
        result.IsValid.Should().Be(true);
    }

    [Fact]
    public void HelloValidatorWithCorrectNameReturnsTrue()
    {
        var helloValidator = new HelloRequestValidator();
        var request = new HelloRequest("test");
        var result = helloValidator.Validate(request);
        result.IsValid.Should().Be(true);
    }

    [Fact]
    public void HelloValidatorWithInCorrectNameReturnsFalse()
    {
        var helloValidator = new HelloRequestValidator();
        var request = new HelloRequest("xxx");
        var result = helloValidator.Validate(request);
        result.IsValid.Should().Be(false);
    }
}