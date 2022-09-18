using System.Collections.Generic;

namespace RegistrationAssistant
{
    internal class Transliteration
    {
        readonly Dictionary<char, string> characters = new Dictionary<char, string>
        {
            { 'А', "A" }, { 'а', "a" },
            { 'Б', "B" }, { 'б', "b" },
            { 'В', "V" }, { 'в', "v" },
            { 'Г', "G" }, { 'г', "g" },
            { 'Д', "D" }, { 'д', "d" },
            { 'Е', "E" }, { 'е', "e" },
            { 'Ё', "E" }, { 'ё', "e" },
            { 'Ж', "Zh" }, { 'ж', "zh" },
            { 'З', "Z" }, { 'з', "z" },
            { 'И', "I" }, { 'и', "i" },
            { 'Й', "I" }, { 'й', "i" },
            { 'К', "K" }, { 'к', "k" },
            { 'Л', "L" }, { 'л', "l" },
            { 'М', "M" }, { 'м', "m" },
            { 'Н', "N" }, { 'н', "n" },
            { 'О', "O" }, { 'о', "o" },
            { 'П', "P" }, { 'п', "p" },
            { 'Р', "R" }, { 'р', "r" },
            { 'С', "S" }, { 'с', "s" },
            { 'Т', "T" }, { 'т', "t" },
            { 'У', "U" }, { 'у', "u" },
            { 'Ф', "F" }, { 'ф', "f" },
            { 'Х', "Kh" }, { 'х', "kh" },
            { 'Ц', "Tc" }, { 'ц', "tc" },
            { 'Ч', "Ch" }, { 'ч', "ch" },
            { 'Ш', "Sh" }, { 'ш', "sh" },
            { 'Щ', "Shch" }, { 'щ', "shch" },
            { 'Ъ', "" }, { 'ъ', "" },
            { 'Ы', "Y" }, { 'ы', "y" },
            { 'Ь', "" }, { 'ь', "" },
            { 'Э', "E" }, { 'э', "e" },
            { 'Ю', "Iu" }, { 'ю', "iu" },
            { 'Я', "Ia" }, { 'я', "ia" },
            { ' ', " " }, { '.', "." }
        };

        public string Execute(string originalString)
        {
            string transliteratedString = "";

            foreach (char c in originalString)
                transliteratedString += characters[c];

            return transliteratedString;
        }
    }
}
