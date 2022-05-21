namespace MyPrintiverse.Core.Tests;

public class StringExtensionsTests
{
	[Fact]
	public void FirstLetterToUpper_Null_StringEmpty()
	{
		string? str = null;

		var result = str.FirstLetterToUpper();

		result
			.Should()
			.Be(string.Empty);
	}

	[Fact]
	public void FirstLetterToUpper_StringEmpty_StringEmpty()
	{
		string? str = null;

		var result = str.FirstLetterToUpper();

		result
			.Should()
			.Be(string.Empty);
	}

	[Fact]
	public void FirstLetterToUpper_WhiteSpace_StringEmpty()
	{
		string? str = null;

		var result = str.FirstLetterToUpper();

		result
			.Should()
			.Be(string.Empty);
	}

	[Theory]
	[InlineData("test", "Test")]
	[InlineData("1est", "1est")]
	[InlineData("2EST", "2est")]
	[InlineData("Test", "Test")]
	[InlineData("Tes2", "Tes2")]
	[InlineData("tEST", "Test")]
	[InlineData("890", "890")]
	public void FirstLetterToUpper_String_StringWithFirstLetterToUpper(string inputString, string expectedResult)
	{
		var result = inputString.FirstLetterToUpper();

		result
			.Should()
			.Be(expectedResult);
	}
}
