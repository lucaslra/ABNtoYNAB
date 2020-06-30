using ABNtoYNAB.BL.Converters;
using ABNtoYNAB.BL.Models;
using CsvHelper.Configuration;

namespace ABNtoYNAB.BL
{
    public class StatementRowMap : ClassMap<ImportRow>
    {
        public StatementRowMap()
        {
            AutoMap();

            base.Map(m => m.TransactionAmount).TypeConverter<DecimalConvert>();
            base.Map(m => m.TransactionDate).TypeConverter<DateTimeConvert>();
        }
    }
}
