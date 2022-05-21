namespace MyPrintiverse.Core.Tests.ValidationTests;

public class OnlyDigitsRuleTests
{
	private readonly OnlyDigitsRule _rule;

	public OnlyDigitsRuleTests()
	{
		_rule = new OnlyDigitsRule();
	}

	[Fact]
	public void Check_Null_ReturnFalse()
	{
		var act = () => _rule.Check(null);

		try
		{
			act.Invoke()
				.Should()
				.BeFalse();
		}
		catch (Exception)
		{
			act.Should()
				.NotThrow();
		}
	}

	[Fact]
	public void Check_StringEmpty_ReturnFalse()
	{
		var value = string.Empty;

		var result = _rule.Check(value);

		result.Should()
			.BeTrue();
	}

	[Theory]
	[InlineData("123")]
	[InlineData("2340985234509")]
	[InlineData("1")]
	[InlineData("0")]
	public void Check_ValidInput_ReturnTrue(string value)
	{
		var result = _rule.Check(value);

		result.Should()
			.BeTrue();
	}

	[Theory]
	[InlineData("%5555")]
	[InlineData("55-555")]
	[InlineData("55 555")]
	[InlineData("Rider7")]
	[InlineData("Ghost")]
	[InlineData(" ")]
	[InlineData("%Nothing%")]
	public void Check_NotValidInput_ReturnFalse(string value)
	{
		var result = _rule.Check(value);

		result.Should()
			.BeFalse();
	}
}