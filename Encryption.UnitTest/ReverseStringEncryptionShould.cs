using FluentAssertions;

namespace Encryption.UnitTest;

public class ReverseStringEncryptionShould
{
    private readonly ReverseStringEncryptionAlgorithm _algorithmUT = new();


    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("abcds@")]
    [InlineData("abcds\"")]
    [InlineData("_aaaa")]
    [InlineData("bbb.aaa")]
    public void ThrowException_OnEncryptRequest_ForInvalidInputString(string invalidString)
    {
        _algorithmUT.Invoking(x=> x.Encrypt(invalidString))
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
    [InlineData("ABCDEF", "FEDCBA")]
    [InlineData("a", "a")]
    [InlineData("123456", "654321")]
    [InlineData("1", "1")]
    [InlineData("q1w2e3r4", "4r3e2w1q")]    
    public void ReverseInputStringWhenEncrypting(string inputString, string outputString)
    {
        var result = _algorithmUT.Encrypt(inputString);
        result.Should().Be(outputString);   
    }

    [Theory]
    [InlineData("ABCDEF", "FEDCBA")]
    [InlineData("a", "a")]
    [InlineData("123456", "654321")]
    [InlineData("1", "1")]
    [InlineData("q1w2e3r4", "4r3e2w1q")]
    public void ReverseInputStringWhenDecrypting(string inputString, string outputString)
    {
        var result = _algorithmUT.Encrypt(inputString);
        result.Should().Be(outputString);
    }
}
