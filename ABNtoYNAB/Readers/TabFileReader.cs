using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using ABNtoYNAB.BL.Interfaces;
using ABNtoYNAB.BL.Models;
using CsvHelper;
using CsvHelper.Configuration;

namespace ABNtoYNAB.BL.Readers
{
    internal class TabFileReader : IYNABFileReader
    {
        private readonly Configuration configuration;

        public TabFileReader() : this(DefaultReaderConfiguration)
        {
        }

        public TabFileReader(Configuration readerConfiguration)
        {
            this.configuration = readerConfiguration;
        }

        internal static Configuration DefaultReaderConfiguration
        {
            get
            {
                var config = new Configuration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = false,
                    Delimiter = "\t",
                    MissingFieldFound = null
                };
                config.RegisterClassMap<ImportRowMap>();

                return config;
            }
        }

        public IEnumerable<ImportRow> GetRecords(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new InvalidDataException($"File '{filePath}' could not be found");
            }

            using var fileReader = new StreamReader(filePath);
            using var fileContent = new CsvReader(fileReader, configuration);

            return fileContent.GetRecords<ImportRow>().ToArray();
        }
    }
}
