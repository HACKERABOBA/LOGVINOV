using System;

namespace LOGVINOV
{
    using System;
    using System.Text;

    class Program
    {
        const string Digits = "0123456789";
        const string Alphabet = "abcdefghijklmnopqrstuvwxyz";
        const string Symbols = " ~`@#$%^&*()_+-=[]{};'\\:\"|,./<>?";

        [Flags]
        public enum PasswordChars
        {
            Digits = 0b0001,
            Alphabet = 0b0010,
            Symbols = 0b0100
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Введите длину пароля: ");
            int passwordLength = int.Parse(Console.ReadLine());
            Console.WriteLine("Из чего будет состоять пароль: ");
            Console.WriteLine("1.Цифр");
            Console.WriteLine("2.Букв");
            Console.WriteLine("3.Цифр и букв");
            Console.WriteLine("4.Спец. символов");
            Console.WriteLine("5.Цифр и спец. символов");
            Console.WriteLine("6.Букв и спец. символов");
            Console.WriteLine("7.Букв, цифр и спец. символов");
            Console.Write("Какой из наборов хотите использовать: ");
            int charSet = int.Parse(Console.ReadLine());
            Console.WriteLine("Ваш пароль: [{0}]", GeneratePassword((PasswordChars)charSet, passwordLength));
            Console.ReadLine();
        }

        private static string GeneratePassword(PasswordChars passwordChars, int length)
        {
            var random = new Random();
            var resultPassword = new StringBuilder(length);
            var passwordCharSet = string.Empty;
            if (passwordChars.HasFlag(PasswordChars.Alphabet))
            {
                passwordCharSet += Alphabet + Alphabet.ToUpper();
            }
            if (passwordChars.HasFlag(PasswordChars.Digits))
            {
                passwordCharSet += Digits;
            }
            if (passwordChars.HasFlag(PasswordChars.Symbols))
            {
                passwordCharSet += Symbols;
            }
            for (var i = 0; i < length; i++)
            {
                resultPassword.Append(passwordCharSet[random.Next(0, passwordCharSet.Length)]);
            }
            return resultPassword.ToString();
        }
    }
}
