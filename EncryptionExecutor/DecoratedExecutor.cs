using Encryption;

namespace EncryptionExecutor;

public sealed class DecoratedExecutor : IEncryptionExecutor
{
    private readonly ISecurityElement _securityElement;
    private readonly IEncryptionExecutor _executor;

    public DecoratedExecutor(ISecurityElement securityElement, IEncryptionExecutor executor)
    {
        _securityElement = securityElement;
        _executor = executor;
    }

    public string ExecuteEncryption(string text) => _executor.ExecuteEncryption(_securityElement.Encrypt(text));

    public string ExecuteDecryption(string text) => _securityElement.Decrypt(_executor.ExecuteDecryption(text));
}
