
//using MyPrintiverse.Tools.Validation;
//namespace MyPrintiverse.Tests.ToolsTests.ValidationTests;

//public class ContainAllRuleTests
//{
//	private readonly ContainAllRule _rule;

//	public ContainAllRuleTests()
//	{
//		_rule = new ContainAllRule('9', ' ', '@', 'A');
//	}

//	[Fact]
//	public void Check_NullConstructor_ThrowException()
//	{
//		var containAllRule = () => _ = new ContainAllRule(null);

//		containAllRule
//			.Should()
//			.Throw<ArgumentNullException>();
//	}

//	[Fact]
//	public void Check_Null_ReturnFalse()
//	{
//		var act = () => _rule.Check(null);
		
//		try
//		{
//			act.Invoke()
//				.Should()
//				.BeFalse();
//		}
//		catch (Exception)
//		{
//			act.Should()
//				.NotThrow();
//		}
//	}

//	[Fact]
//	public void Check_StringEmpty_ReturnFalse()
//	{
//		var value = string.Empty;

//		var result = _rule.Check(value);

//		result.Should()
//			.BeFalse();
//	}

//	[Theory]
//	[InlineData("Test9")]
//	[InlineData("Test@Test")]
//	[InlineData("9 @A")]
//	[InlineData("9 @")]
//	[InlineData("TestA")]
//	[InlineData("A")]
//	[InlineData(" ")]
//	public void Check_ValidInput_ReturnTrue(string value)
//	{
//		var result = _rule.Check(value);

//		result.Should()
//			.BeTrue();
//	}

//	[Theory]
//	[InlineData("Test")]
//	[InlineData("1237123")]
//	[InlineData("QWE")]
//	[InlineData("qwe")]
//	[InlineData("1Test1")]
//	public void Check_NotValidInput_ReturnFalse(string value)
//	{
//		var result = _rule.Check(value);

//		result.Should()
//			.BeFalse();
//	}
//}