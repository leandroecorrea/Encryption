using FluentAssertions;

namespace Encryption.UnitTest;

public class RecursiveEncryptionAlgorithmShould
{
    private readonly RecursiveEncryptionAlgorithm _algorithmUT = new();    


    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("abcds@")]
    [InlineData("abcds\"")]
    [InlineData("_aaaa")]
    [InlineData("bbb.aaa")]
    public void ThrowException_OnEncryptRequest_ForInvalidInputString(string invalidString)
    {
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
        _algorithmUT.Invoking(x => x.Decrypt(invalidString))
            .Should()
            .Throw<ArgumentException>();
    }

    [Theory]
    [InlineData("aaaaa", "AAAAA")]
    [InlineData("bbbbb", "BBBBB")]
    [InlineData("aaaAA", "AAAaa")]
    [InlineData("q1w2e3r4", "Q1W2E3R4")]    
    public void ChangeCaseToAllLetters_OnEncryption(string inputString, string expectedOutput)
    {
        var result = _algorithmUT.Encrypt(inputString);
        result.Should().Be(expectedOutput);
    }


    [Theory]
    [InlineData("aaaaa", "AAAAA")]
    [InlineData("bbbbb", "BBBBB")]
    [InlineData("aaaAA", "AAAaa")]
    [InlineData("q1w2e3r4", "Q1W2E3R4")]
    public void ChangeCaseToAllLetters_OnDecryption(string inputString, string expectedOutput)
    {
        var result = _algorithmUT.Encrypt(inputString);
        result.Should().Be(expectedOutput);
    }
}