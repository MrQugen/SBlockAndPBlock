namespace SBlockAndPBlock;

public class Program
{
    public static void Main()
    {
        const string input = "Hello, World!";
        const string key = "SecretKey";

        var ciphertext = BlockCipher.Encrypt(input, key);
        Console.WriteLine("Зашифрованный текст: " + ciphertext);

        var decryptedText = BlockCipher.Decrypt(ciphertext, key);
        Console.WriteLine("Расшифрованный текст: " + decryptedText);
    }
}
