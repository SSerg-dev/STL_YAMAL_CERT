using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace SmartQA1._1._2.Service
{
    public class ToolKit
    {
        /// <summary>
        /// Конвертирует строку, представляющую шестнадцатиричное число, в массив байт.
        /// </summary>
        /// <param name="Hex">Строка для конвертирования. "0x" в начале строки допустим, но не обязателен.</param>
        /// <param name="i">Начальная позиция символа в строке <paramref name="Hex"/>.
        /// НЕ МЕНЯТЬ значение по умолчанию!</param>
        /// <returns>Массив байт или <see langword="null"/>.</returns>
        public static byte[] String2ByteArray(string Hex, int i = -2) =>
            string.IsNullOrWhiteSpace(Hex) ||
            //Если строка Hex начинается с "0x", выбираем все символы после "0x".            
            (Hex.StartsWith("0x") ? Hex = Hex.Substring(2) : Hex)
            //После "0x" должны быть символы (длина строки не ноль), количество символов в строке должно быть чётным.
            .Length == 0 || Hex.Length % 2 != 0 ? null :
            //Выбираем только те символы, которые расположены на чётных позициях строки.
            Hex.Where((x, j) => j % 2 == 0)
            .Select(x => byte.Parse(Hex.Substring(i += 2, 2), NumberStyles.HexNumber)).ToArray();
        /// <summary>
        /// Соединяет все непустые строки <paramref name="strings"/> через строку-разделитель <paramref name="separator"/>.
        /// </summary>
        /// <param name="separator">Строка-разделитель.</param>
        /// <param name="strings">Строки для соединения.</param>
        /// <returns>Натуральный ключ в виде строки, разделённой <paramref name="separator"/>,
        /// если в <paramref name="strings"/> есть хотя бы одна непустая строка, иначе <see langword="null"/>.</returns>
        public static string NaturalKey(string separator, params string[] strings) =>
            string.Join(separator, strings.Where(x => !string.IsNullOrWhiteSpace(x)).ToList())
                .Split(new[] { string.Empty }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();
        public static Action<string> writeOutput = (x) => Debug.WriteLine(x);
    }
}