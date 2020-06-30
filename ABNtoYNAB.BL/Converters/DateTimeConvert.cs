using System;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace ABNtoYNAB.BL.Converters
{
    internal class DateTimeConvert : ITypeConverter
    {
        private const string dateFormat = "yyyyMMdd";

        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData) => DateTime.ParseExact(text, dateFormat, CultureInfo.InvariantCulture);

        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData) => ((DateTime)value).ToString(dateFormat);
    }
}
