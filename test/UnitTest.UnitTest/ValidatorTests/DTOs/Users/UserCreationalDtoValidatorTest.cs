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


    [Theory]
    [InlineData("+998937778899")]
    [InlineData("+998937778896")]
    [InlineData("+998907778899")]
    [InlineData("+998937775899")]
    [InlineData("+998937278899")]
    public void PhoneNumberShouldReturnCorrect(string phone)
    {
        var example = new UserCreationalDto
        {
            FirstName = "Muqimjon",
            LastName = "Mamadaliyev",
            PhoneNumber = phone,
            Email = "muqimjon@gmail.com",
            Password = "AAaa1!"
        };

        var validator = new UserCreationDtoValidator();
        var result = validator.Validate(example);

        Assert.True(result.IsValid);
    }


    [Theory]
    [InlineData("+99893777889O")]
    [InlineData("+9989S7778896")]
    [InlineData("+99893777589 ")]
    [InlineData("+909937278896")]
    [InlineData("998937278899")]
    [InlineData("+99890778899")]
    [InlineData("+990937278899")]
    [InlineData("+999937278899")]
    [InlineData("+958037278899")]
    public void PhoneNumberShouldReturnWrong(string phone)
    {
        var example = new UserCreationalDto
        {
            FirstName = "Muqimjon",
            LastName = "Mamadaliyev",
            PhoneNumber = phone,
            Email = "muqimjon@gmail.com",
            Password = "AAaa1!"
        };

        var validator = new UserCreationDtoValidator();
        var result = validator.Validate(example);

        Assert.False(result.IsValid);
    }
}