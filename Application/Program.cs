using EncryptionExecutor;

var encryptor = EncryptionProvider.Create();

string[] toEncryptArray = [
        "HOLA",
        "pepe",
        "123456",
        "hola123Mundo"
    ];

foreach(var toEncrypt in toEncryptArray)
{
    Console.WriteLine($"Palabra a encriptar: {toEncrypt}");
    var encrypted = encryptor.ExecuteEncryption(toEncrypt);
    Console.WriteLine($"Palabra encriptada: {encrypted}");
    var decrypted = encryptor.ExecuteDecryption(encrypted);
    Console.WriteLine($"Palabra desencriptada: {decrypted}");
}