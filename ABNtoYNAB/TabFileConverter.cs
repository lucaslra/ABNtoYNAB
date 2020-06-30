using System.Threading.Tasks;
using ABNtoYNAB.BL.Interfaces;
using ABNtoYNAB.BL.Readers;
using CsvHelper.Configuration;

namespace ABNtoYNAB.BL
{
    public class TabFileConverter : IYNABFileConverter
    {
        private readonly string tabFile;
        private readonly TabFileReader fileReader;
        private readonly TabFileWriter fileWriter;

        public TabFileConverter(string tabFile)
        : this(tabFile,
               TabFileReader.DefaultReaderConfiguration,
               TabFileWriter.DefaultWriterConfiguration)
        { }

        public TabFileConverter(string tabFile,
                                Configuration readerConfiguration,
                                Configuration writerConfiguration)
        {
            this.tabFile = tabFile;
            fileReader = new TabFileReader(readerConfiguration);
            fileWriter = new TabFileWriter(writerConfiguration);
        }

        public async Task ExportAsYNAB()
        {
            var records = fileReader.GetRecords(tabFile);
            await fileWriter.WriteRecordsAsync(records);
        }
    }
}
