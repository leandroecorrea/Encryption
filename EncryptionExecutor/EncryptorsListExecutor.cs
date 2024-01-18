using Encryption;

namespace EncryptionExecutor;

public class EncryptorsListExecutor : IEncryptionExecutor
{
    private readonly List<ISecurityElement> _executorList = [
            new RecursiveEncryptionAlgorithm(),
            new ReverseStringEncryptionAlgorithm(),
            new CharacterReplacementEncryptionAlgorithm(x => x + 1, x => x - 1)
        ];

    public string ExecuteEncryption(string text)
    {
        string encrypted = text;
        foreach(var executor in _executorList)
        {
            encrypted = executor.Encrypt(encrypted);
        }
        return encrypted;
    }

    public string ExecuteDecryption(string text)
    {
        string decrypted = text;
        for (int i = _executorList.Count-1; i >= 0; i--)
        {
            decrypted = _executorList[i].Decrypt(decrypted);
        }
        return decrypted;
    }
}