namespace MyPrintiverse.Core.Tests.ValidationTests;

public class RangeRuleTests
{
	[Fact]
	public void Check_Null_ReturnFalse()
	{
		//var act = () => rule.Check(null);

		//try
		//{
		//	act.Invoke()
		//		.Should()
		//		.BeFalse();
		//}
		//catch (Exception)
		//{
		//	act.Should()
		//		.NotThrow();
		//}
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

		//result.Should()
		//	.BeTrue();
	}

	[Theory]
	[InlineData("")]
	public void Check_NotValidInput_ReturnFalse(string value)
	{
		//var result = _onlyDigitsRule.Check(value);

		//result.Should()
		//	.BeFalse();
	}
}