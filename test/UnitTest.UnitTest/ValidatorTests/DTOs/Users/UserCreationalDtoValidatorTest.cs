using UnitTest.Service.DTOs.Users;
using UT.Service.Validators;

namespace UT.UnitTest.ValidatorTests.DTOs.Users;

public class UserCreationalDtoValidatorTest
{
    [Fact]
    public void ShouldReturnCorrect()
    {
        var example = new UserCreationalDto
        {
            FirstName = "Muqimjon",
            LastName = "Mamadaliyev",
            PhoneNumber = "+998998887766",
            Email = "muqimjon@gmail.com",
            Password = "AAaa1!"
        };

        var validator = new UserCreationDtoValidator();
        var result = validator.Validate(example);

        Assert.True(result.IsValid);
    }

    [Fact]
    public void ShouldReturnWrong()
    {
        var example = new UserCreationalDto
        {
            FirstName = "AA",
            LastName = "BB",
            PhoneNumber = "998998887766",
            Email = "muqimjon.gmail.com",
            Password = "AAaa1"
        };

        var validator = new UserCreationDtoValidator();
        var result = validator.Validate(example);

        Assert.False(result.IsValid);
    }
}