using FluentAssertions;

namespace Encryption.UnitTest;

public class CharacterReplacementEncryptionAlgorithmShould
{
    private CharacterReplacementEncryptionAlgorithm _algorithmUT;
        

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("abcds@")]
    [InlineData("abcds\"")]
    [InlineData("_aaaa")]
    [InlineData("bbb.aaa")]
    public void ThrowException_OnEncryptRequest_ForInvalidInputString(string invalidString)
    {
        Func<int, int> emptyFunction = (int value) => value;
        _algorithmUT = new(emptyFunction, emptyFunction);
        _algorithmUT.Invoking(x => x.Encrypt(invalidString))
            .Should()
            .Throw<ArgumentException>();
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("abcds@")]
    [InlineData("abcds\"")]
    [InlineData("_aaaa")]
    [InlineData("bbb.aaa")]
    public void ThrowException_OnDecryptRequest_ForInvalidInputString(string invalidString)
    {
        Func<int, int> emptyFunction = (int value) => value;
        _algorithmUT = new(emptyFunction, emptyFunction);
        _algorithmUT.Invoking(x => x.Decrypt(invalidString))
            .Should()
            .Throw<ArgumentException>();
    }


    [Theory]
    [InlineData("ABCDEF")]
    [InlineData("a")]
    [InlineData("123456")]
    [InlineData("1")]
    [InlineData("q1w2e3r4")]
    public void NotModifyString_WhenEncryptionFunctionDoesNotApplyChanges(string inputString)
    {        
        Func<int, int> emptyFunction = (int value) => value;
        _algorithmUT = new(emptyFunction, emptyFunction);
        var result = _algorithmUT.Encrypt(inputString);
        result.Should().Be(inputString);
    }

    [Theory]
    [InlineData("abcdef", "bcdefg")]    
    [InlineData("ABCDEF", "BCDEFG")]
    [InlineData("012345", "123456")]
    public void ModifyEachCharacterToNext_WhenEncryptionFunctionShiftsByOne(string inputString, string expectedOutput)
    {
        Func<int, int> shiftByOneFunction = (int value) => ++value;
        _algorithmUT = new(shiftByOneFunction, shiftByOneFunction);
        var result = _algorithmUT.Encrypt(inputString);
        result.Should().Be(expectedOutput);
    }


    [Theory]
    [InlineData("ABCDEF")]
    [InlineData("a")]
    [InlineData("123456")]
    [InlineData("1")]
    [InlineData("q1w2e3r4")]
    public void NotModifyString_WhenDecryptionFunctionDoesNotApplyChanges(string inputString)
    {
        Func<int, int> emptyFunction = (int value) => value;
        _algorithmUT = new(emptyFunction, emptyFunction);
        var result = _algorithmUT.Decrypt(inputString);
        result.Should().Be(inputString);
    }

    [Theory]
    [InlineData("abcdef", "bcdefg")]
    [InlineData("ABCDEF", "BCDEFG")]
    [InlineData("012345", "123456")]
    public void ModifyEachCharacterToNext_WhenDecryptionFunctionShiftsByOne(string inputString, string expectedOutput)
    {
        Func<int, int> shiftByOneFunction = (int value) => ++value;
        _algorithmUT = new(shiftByOneFunction, shiftByOneFunction);
        var result = _algorithmUT.Decrypt(inputString);
        result.Should().Be(expectedOutput);
    }

}
