namespace MyPrintiverse.Tests;

public class AuthorizationValidationTests
{
	[Fact]
	public void Email_Null_ReturnFalse()
	{

	}

	[Fact]
	public void Email_StringEmpty_ReturnFalse()
	{
			
	}

	[Theory]
	[InlineData("")]
	public void Email_ValidInput_ReturnTrue(string emailSample)
	{

	}

	[Theory]
	[InlineData("")]
	public void Email_NotValid_ReturnFalse(string Sample)
	{

	}

	[Fact]
	public void Name_Null_ReturnFalse()
	{

	}

	[Fact]
	public void Name_StringEmpty_ReturnFalse()
	{

	}

	[Theory]
	[InlineData("")]
	public void Name_ValidInput_ReturnTrue(string nameSample)
	{

	}

	[Theory]
	[InlineData("")]
	public void Name_NotValid_ReturnFalse(string Sample)
	{

	}

	[Fact]
	public void PhoneNumber_Null_ReturnFalse()
	{

	}

	[Fact]
	public void PhoneNumber_StringEmpty_ReturnFalse()
	{

	}

	[Theory]
	[InlineData("")]
	public void PhoneNumber_ValidInput_ReturnTrue(string phoneNumberSample)
	{

	}

	[Theory]
	[InlineData("")]
	public void PhoneNumber_NotValid_ReturnFalse(string Sample)
	{

	}

	[Fact]
	public void Password_Null_ReturnFalse()
	{

	}

	[Fact]
	public void Password_StringEmpty_ReturnFalse()
	{

	}

	[Theory]
	[InlineData("")]
	public void Password_ValidInput_ReturnTrue(string passwordSample)
	{

	}

	[Theory]
	[InlineData("")]
	public void Password_NotValid_ReturnFalse(string Sample)
	{

	}

	[Fact]
	public void RemindCode_Null_ReturnTrue()
	{

	}

	[Fact]
	public void RemindCode_StringEmpty_ReturnTrue()
	{

	}

	[Theory]
	[InlineData("")]
	public void RemindCode_ValidInput_ReturnTrue(string remindCodeSample)
	{

	}

	[Theory]
	[InlineData("")]
	public void RemindCode_NotValid_ReturnFalse(string Sample)
	{

	}
}