
namespace Encryption;
    
public abstract class BaseSecurityElement : ISecurityElement
{
    protected abstract string ApplyDecryption(string text);
    protected abstract string ApplyEncryption(string text);
    public string Decrypt(string text)
    {
        ValidateInputString(text);
        return ApplyDecryption(text);
    }

    public string Encrypt(string text)
    {
        ValidateInputString(text);
        return ApplyEncryption(text);
    }

    private static void ValidateInputString(string text)
    {
        if (IsNotValidInputString(text))
            throw new ArgumentException($"Input string {text} is not valid");
    }

    private static bool IsNotValidInputString(string text)
        => string.IsNullOrEmpty(text) || text.Any(x => !char.IsLetterOrDigit(x));
}