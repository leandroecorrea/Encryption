namespace EncryptionExecutor;

public interface IEncryptionExecutor
{
    string ExecuteDecryption(string text);
    string ExecuteEncryption(string text);
}
