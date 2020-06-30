using System;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace ABNtoYNAB.BL.Converters
{
    public class DecimalConvert : ITypeConverter
    {
        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            text = text.Replace(",", CultureInfo.InvariantCulture.NumberFormat.CurrencyDecimalSeparator);

            if (decimal.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out var value))
            {
                return value;
            }

            throw new ArgumentException("Invalid Type", nameof(text));
        }

        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            return value.ToString();
        }
    }
}
