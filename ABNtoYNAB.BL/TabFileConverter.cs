using System;
using System.IO;
using System.Threading.Tasks;
using ABNtoYNAB.BL.Models;
using CsvHelper;

namespace ABNtoYNAB.BL
{
    public class TabFileConverter : IYNABFileConverter
    {
        private readonly string abnFilePath;

        public TabFileConverter(string abnFilePath) => this.abnFilePath = abnFilePath;

        public async Task ExportAsYNAB()
        {
            using var fileReader = new StreamReader(abnFilePath);
            using var fileContent = new CsvReader(fileReader, Configuration.ReaderConfiguration());

            using var fileWriter = new StreamWriter($"YNAB_{DateTime.Now:yyyyMMdd}.csv");
            using var fileDocument = new CsvWriter(fileWriter, Configuration.WriterConfiguration());

            fileDocument.WriteHeader<ExportRow>();
            await fileDocument.NextRecordAsync();

            foreach (var item in fileContent.GetRecords<ImportRow>())
            {
                fileDocument.WriteRecord(item.ToExport());
                await fileDocument.NextRecordAsync();
            }
        }
    }
}
