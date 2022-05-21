namespace MyPrintiverse.Core.Tests.ValidationTests;

public class ContainUpperTests
{
	private readonly ContainUpperRule _rule;

	public ContainUpperTests()
	{
		_rule = new ContainUpperRule();
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
			.BeFalse();
	}

	[Theory]
	[InlineData("TEST")]
	[InlineData("1Test1")]
	[InlineData("Test9")]
	[InlineData("Test@Test")]
	[InlineData("TestA")]
	public void Check_ValidInput_ReturnTrue(string value)
	{
		var result = _rule.Check(value);

		result.Should()
			.BeTrue();
	}

	[Theory]
	[InlineData("test")]
	[InlineData("1237123")]
	[InlineData("qwe")]
	[InlineData("9 @")]
	[InlineData("a")]
	[InlineData(" ")]
	[InlineData("!@*#()777")]
	public void Check_NotValidInput_ReturnFalse(string value)
	{
		var result = _rule.Check(value);

		result.Should()
			.BeFalse();
	}
}