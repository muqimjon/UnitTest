using UT.Service.Validators;

namespace UT.UnitTest.ValidatorTests;

public class PhoneNumberValidatorTest
{
    [Fact]
    public void ShouldReturnCorrect()
    {
        var validator = new PhoneNumberValidator();
        var examplePhone = "+998937349828";
        var result = validator.IsValid(examplePhone);
        Assert.True(result);
    }

}