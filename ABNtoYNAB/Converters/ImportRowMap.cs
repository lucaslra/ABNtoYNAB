using ABNtoYNAB.BL.Converters;
using ABNtoYNAB.BL.Models;
using CsvHelper.Configuration;

namespace ABNtoYNAB.BL
{
    public class ImportRowMap : ClassMap<ImportRow>
    {
        public ImportRowMap()
        {
            AutoMap();

            base.Map(m => m.TransactionAmount).TypeConverter<DecimalConvert>();
            base.Map(m => m.TransactionDate).TypeConverter<DateTimeConvert>();
        }
    }
}
