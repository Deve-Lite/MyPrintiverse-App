namespace MyPrintiverse.Tests.ToolsTests.ValidationTests;

public class CustomRuleTests
{
	[Fact]
	public void Check_Null_ReturnFalse()
	{

	}

	[Fact]
	public void Check_Default_ReturnFalse()
	{

	}

	[Theory]
	[InlineData("")]
	public void Check_ValidInput_ReturnTrue(string value)
	{
		//var result = _onlyDigitsRule.Check(value);

		//result.Should().BeTrue();
	}

	[Theory]
	[InlineData("")]
	public void Check_NotValidInput_ReturnFalse(string value)
	{
		//var result = _onlyDigitsRule.Check(value);

		//result.Should().BeFalse();
	}
}