using System;
using System.Globalization;
using System.Diagnostics;
using System.Data.SqlTypes;
using System.Linq;

namespace SmartQA1._1._2
{
    public class DateKit
	{
        /// <summary>
        /// Конвертирует строку <paramref name="Date"/>, представляющую дату-время, в дату <see cref="DateTime"/>.
        /// </summary>
        /// <param name="Date">Строка для конвертирования.</param>
        /// <returns>Дата в случае успеха, иначе <see langword="null"/>.</returns>
        public static DateTime? String2DateTime(string Date)
		{
            if (string.IsNullOrWhiteSpace(Date)) return null;
            try { return DateTime.ParseExact(Date, "dd.MM.yyyy", CultureInfo.InvariantCulture); }
            catch (FormatException) {
                Debug.WriteLine("DateKit: Attempted to convert not valid date format string to DateTime format");
                return null;
            }
        }
        /// <summary>
        /// Проверяет <see cref="DateTime"/> даты <paramref name="Dates"/> на соответствие <see cref="SqlDateTime"/>.
        /// </summary>
        /// <param name="Dates">Даты для проверки.</param>
        /// <returns><paramref name="Dates"/> без изменений, если ВСЕ даты прошли проверку,
        /// иначе <see langword="null"/>.</returns>
        public static DateTime?[] DateTime2Sql(params DateTime?[] Dates) =>
            Dates == null ? Dates
            : Dates.Any(x => !x.HasValue || x < SqlDateTime.MinValue.Value || x > SqlDateTime.MaxValue.Value) ?
                null : Dates;
	    /// <summary>
	    /// Проверяет <see cref="DateTime"/> дату <paramref name="Date"/> на соответствие <see cref="SqlDateTime"/>.
	    /// </summary>
	    /// <param name="Date">Дата для проверки.</param>
	    /// <returns><paramref name="Date"/> без изменений, если соответствует,
	    /// иначе <see langword="null"/>.</returns>
	    public static DateTime? DateTime2Sql(DateTime? Date) => Date == null ? Date
            : DateTime2Sql(new[] { Date }) == null ? null : Date;
	    public static string convertToUIDate(DateTime inputDateTime) =>
            inputDateTime == default(DateTime) ? string.Empty : $@"{inputDateTime:dd\/MM\/yyyy}";
        public static string convertToUIDate(DateTimeOffset? inputDateTime) =>
            inputDateTime.HasValue ? $@"{inputDateTime.Value.LocalDateTime:dd\/MM\/yyyy}" : string.Empty;
    }
}