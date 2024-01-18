using Encryption;

namespace EncryptionExecutor;

public class EncryptionExecutor : IEncryptionExecutor
{
    private readonly ISecurityElement _securityElement;

    public EncryptionExecutor(ISecurityElement securityElement)
    {
        _securityElement = securityElement;
    }

    public string ExecuteDecryption(string text) => _securityElement.Decrypt(text);

    public string ExecuteEncryption(string text) => _securityElement.Encrypt(text);
}
