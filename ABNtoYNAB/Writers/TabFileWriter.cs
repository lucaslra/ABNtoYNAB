using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using ABNtoYNAB.BL.Interfaces;
using ABNtoYNAB.BL.Models;
using CsvHelper;
using CsvHelper.Configuration;

namespace ABNtoYNAB.BL
{
    internal class TabFileWriter : IYNABFileWriter
    {
        internal static Configuration DefaultWriterConfiguration
        {
            get
            {
                var config = new Configuration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true
                };

                return config;
            }
        }

        internal static string DefaultFileName = $"YNAB_{DateTime.Now:yyyyMMdd}.csv";

        private readonly string fileName;

        private readonly Configuration writerConfiguration;

        internal TabFileWriter() : this(DefaultFileName, DefaultWriterConfiguration) { }

        internal TabFileWriter(Configuration writerConfiguration) : this(DefaultFileName, writerConfiguration) { }

        internal TabFileWriter(string fileName) : this(fileName, DefaultWriterConfiguration) { }

        internal TabFileWriter(string fileName, Configuration writerConfiguration)
        {
            this.fileName = fileName;
            this.writerConfiguration = writerConfiguration;
        }

        public async Task WriteRecordsAsync(IEnumerable<ImportRow> importRows)
        {
            using var fileWriter = new StreamWriter(fileName);
            using var fileDocument = new CsvWriter(fileWriter, writerConfiguration);

            fileDocument.WriteHeader<ExportRow>();
            await fileDocument.NextRecordAsync();

            foreach (var item in importRows)
            {
                fileDocument.WriteRecord(item.ToExport());
                await fileDocument.NextRecordAsync();
            }
        }

        public void WriteRecords(IEnumerable<ImportRow> importRows) => WriteRecordsAsync(importRows).Wait();
    }
}
