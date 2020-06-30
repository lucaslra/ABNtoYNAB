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

            return decimal.Parse(text, NumberStyles.Any, CultureInfo.InvariantCulture);
        }

        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData) => value.ToString();
    }
}
