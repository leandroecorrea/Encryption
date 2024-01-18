namespace Encryption;

public class RecursiveEncryptionAlgorithm : BaseSecurityElement
{
    protected override string ApplyDecryption(string text)
        => ReverseCase(text);

    private static string ReverseCase(string text)
        => string.IsNullOrEmpty(text) ? "" : ReverseCase(text.First()) + ReverseCase(string.Join("", text.Skip(1)));

    protected override string ApplyEncryption(string text)
        => ReverseCase(text);

    private static char ReverseCase(char character) 
        => char.IsLetter(character) switch
        {
            true when char.IsUpper(character) => char.ToLower(character),
            true when char.IsLower(character) => char.ToUpper(character),
            _ => character,
        };
}
