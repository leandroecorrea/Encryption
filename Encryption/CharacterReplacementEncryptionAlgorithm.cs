
using System.Text;

namespace Encryption;


public class CharacterReplacementEncryptionAlgorithm : BaseSecurityElement
{
    private readonly Func<int, int> _encryptFunction;
    private readonly Func<int, int> _decryptFunction;

    public CharacterReplacementEncryptionAlgorithm(Func<int, int> encryptFunction, Func<int, int> decryptFunction)
    {
        _encryptFunction = encryptFunction;
        _decryptFunction = decryptFunction;
    }

    //DDD example
    public static CharacterReplacementEncryptionAlgorithm Create(Func<int, int> encryptFunction, Func<int, int> decryptFunction)
    {
        int value = 1;
        if(decryptFunction(encryptFunction(value)) != value) 
        {
            throw new ArgumentException("Functions do not match");
        }
        return new(encryptFunction, decryptFunction);
    }

    protected override string ApplyDecryption(string text)
        => ModifyStringWith(text, _decryptFunction);

    protected override string ApplyEncryption(string text) =>
        ModifyStringWith(text, _encryptFunction);

    private static string ModifyStringWith(string text, Func<int, int> function)
        => string.Join("", Encoding.ASCII.GetBytes(text)
            .Select(x => (char)function(x)));
}
