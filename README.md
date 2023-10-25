# Шифрування з використанням власних S-Box та P-Box

Це проста програма на C#, яка демонструє шифрування та дешифрування з використанням власних S-Box та P-Box. Вона дозволяє вам зашифрувати текстовий рядок за допомогою заданого ключа та потім розшифрувати його, використовуючи той самий ключ.

## Використання

1. Клонуйте цей репозиторій на свій локальний комп'ютер або завантажте вихідний код.

2. Відкрийте проект в Visual Studio або іншому середовищі розробки C# за вашим вибором.

3. Побудуйте і запустіть проект.

4. Програма зашифрує, а потім розшифрує зразковий текстовий рядок за допомогою власного S-Box та P-Box, які генеруються з секретного ключа.

5. Ви можете змінити змінні `input` та `key` в методі `Main`, щоб зашифрувати власний текст із власним ключем.

## Приклад

```csharp
string input = "Привіт, світе!";
string key = "СекретнийКлюч";

string ciphertext = Encrypt(input, key);
Console.WriteLine("Зашифрований текст: " + ciphertext);

string decryptedText = Decrypt(ciphertext, key);
Console.WriteLine("Розшифрований текст: " + decryptedText);

Зашифрований текст: 1B2BtLfOrjBqoL/8HtIiWA==
Розшифрований текст: Привіт, світе!

Опис методів
GenerateSBox(string key)
Цей метод генерує S-Box (підстановочну таблицю) на основі заданого ключа. Він ініціалізує S-Box вихідними значеннями від 0 до 255 та перемішує їх на основі ключа.

GeneratePBox(string key)
Цей метод генерує P-Box (перестановочну таблицю) на основі заданого ключа. Він ініціалізує P-Box вихідними значеннями від 0 до 255 та перемішує їх на основі ключа.

Swap(byte[] arr, int i, int j)
Цей метод використовується для обміну двох елементів в масиві.

Encrypt(string input, string key)
Цей метод призначений для шифрування текстового рядка input з використанням S-Box та P-Box, згенерованих з ключа key. Результатом є зашифрований текст у форматі Base64.

Decrypt(string ciphertext, string key)
Цей метод використовується для розшифрування зашифрованого тексту ciphertext за допомогою S-Box та P-Box, згенерованих з ключа key. Результатом є розшифрований текст.

Можна змінювати змінні input та key, щоб експериментувати з різними входами та ключами.
