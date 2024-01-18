
namespace Encryption;

public class ReverseStringEncryptionAlgorithm : BaseSecurityElement
{    
    protected override string ApplyDecryption(string text)
        => string.Join("", text.Reverse());

    protected override string ApplyEncryption(string text)
        => string.Join("", text.Reverse());
}
