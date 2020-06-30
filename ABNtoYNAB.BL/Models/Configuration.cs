using System.Globalization;
using CsvConfiguration = CsvHelper.Configuration.Configuration;

namespace ABNtoYNAB.BL.Models
{
    internal class Configuration
    {
        internal static CsvConfiguration ReaderConfiguration()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                Delimiter = "\t"
            };
            config.RegisterClassMap<StatementRowMap>();

            return config;
        }

        internal static CsvConfiguration WriterConfiguration()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true
            };

            return config;
        }
    }
}
