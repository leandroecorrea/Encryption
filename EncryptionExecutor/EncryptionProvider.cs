using Encryption;

namespace EncryptionExecutor;

public static class EncryptionProvider
{
    public static IEncryptionExecutor Create()
    {
        //return new EncryptorsListExecutor();
        IEncryptionExecutor first = new EncryptionExecutor(new RecursiveEncryptionAlgorithm());
        IEncryptionExecutor second = new DecoratedExecutor(new ReverseStringEncryptionAlgorithm(), first);
        IEncryptionExecutor last = new DecoratedExecutor(new CharacterReplacementEncryptionAlgorithm(x => x + 1, x => x - 1), second);
        return last;
    }
}
