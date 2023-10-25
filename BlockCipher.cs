using System.Text;

namespace SBlockAndPBlock;

public static class BlockCipher
{
    // Генерация S-блока на основе ключа
    private static byte[] GenerateSBox(string key)
    {
        var sBlock = new byte[256];
        var keyBytes = Encoding.UTF8.GetBytes(key);
        var rand = new Random(BitConverter.ToInt32(keyBytes, 0));

        // Инициализация S-блока начальными значениями от 0 до 255
        for (var i = 0; i < 256; i++)
        {
            sBlock[i] = (byte)i;
        }

        // Перемешивание S-блока на основе ключа
        for (var i = 0; i < 256; i++)
        {
            var j = rand.Next(256);
            Swap(sBlock, i, j);
        }

        return sBlock;
    }

    // Генерация P-блока на основе ключа
    private static byte[] GeneratePBox(string key)
    {
        var pBlock = new byte[256];
        var keyBytes = Encoding.UTF8.GetBytes(key);
        var rand = new Random(BitConverter.ToInt32(keyBytes, 0));

        // Инициализация P-блока начальными значениями от 0 до 255
        for (var i = 0; i < 256; i++)
        {
            pBlock[i] = (byte)i;
        }

        // Перемешивание P-блока на основе ключа
        for (var i = 0; i < 256; i++)
        {
            var j = rand.Next(256);
            Swap(pBlock, i, j);
        }

        return pBlock;
    }

    // Метод для обмена двух элементов в массиве
    private static void Swap(IList<byte> arr, int i, int j)
    {
        (arr[i], arr[j]) = (arr[j], arr[i]);
    }

    // Шифрование текста
    public static string Encrypt(string input, string key)
    {
        var sBox = GenerateSBox(key);
        var pBox = GeneratePBox(key);

        var plaintextBytes = Encoding.UTF8.GetBytes(input);
        var ciphertextBytes = new List<byte>();

        for (var i = 0; i < plaintextBytes.Length; i++)
        {
            // Применение S-блока к байту и P-блока к соответствующему индексу
            var sBoxValue = sBox[plaintextBytes[i]];
            var pBoxValue = pBox[i % 256];

            // Применение операции XOR для шифрования
            ciphertextBytes.Add((byte)(sBoxValue ^ pBoxValue));
        }

        // Преобразование массива байт в строку Base64
        return Convert.ToBase64String(ciphertextBytes.ToArray());
    }

    // Дешифрование текста
    public static string Decrypt(string ciphertext, string key)
    {
        var sBox = GenerateSBox(key);
        var pBox = GeneratePBox(key);

        var ciphertextBytes = Convert.FromBase64String(ciphertext);
        var plaintextBytes = new byte[ciphertextBytes.Length];

        for (var i = 0; i < ciphertextBytes.Length; i++)
        {
            // Получение соответствующего значения из P-блока
            var pBoxValue = pBox[i % 256];

            // Дешифрование байта с помощью обратного S-блока
            var encryptedByte = (byte)(ciphertextBytes[i] ^ pBoxValue);

            // Поиск исходного значения в S-блоке
            for (var j = 0; j < 256; j++)
            {
                if (sBox[j] != encryptedByte) continue;
                plaintextBytes[i] = (byte)j;
                break;
            }
        }

        // Преобразование массива байт в строку
        return Encoding.UTF8.GetString(plaintextBytes);
    }
}