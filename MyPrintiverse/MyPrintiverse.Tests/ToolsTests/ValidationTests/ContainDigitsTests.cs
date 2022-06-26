using MyPrintiverse.Tools.Validation;

namespace MyPrintiverse.Tests.ToolsTests.ValidationTests;

public class ContainDigitsTests
{
	private readonly ContainDigitsRule _rule;

	public ContainDigitsTests()
	{
		_rule = new ContainDigitsRule();
	}

	[Theory]
	[InlineData("1234567890")]
	[InlineData("Test1")]
	[InlineData("2Test2")]
	[InlineData("2Test")]
	[InlineData("2  2")]
	[InlineData("!@*#()666")]
	public void Check_ValidInput_ReturnTrue(string value)
	{
		var result = _rule.Check(value);

		result.Should()
			.BeTrue();
	}

	[Theory]
	[InlineData("test")]
	[InlineData("TEST")]
	[InlineData("Test")]
	[InlineData("Test*Test")]
	[InlineData("!@#$%^&*()")]
	[InlineData(" ")]
	public void Check_NotValidInput_ReturnFalse(string value)
	{
		var result = _rule.Check(value);

		result.Should()
			.BeFalse();
	}
}