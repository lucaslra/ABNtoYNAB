using System;
using CsvHelper.Configuration.Attributes;

namespace ABNtoYNAB.BL.Models
{
    public class ImportRow
    {
        [Index(7)]
        public string Description { get; set; }

        [Index(6)]
        public decimal TransactionAmount { get; set; }

        [Index(2)]
        public DateTime TransactionDate { get; set; }

        public ExportRow ToExport()
        {
            return new ExportRow
            {
                Date = TransactionDate,
                Memo = Description,
                Amount = TransactionAmount
            };
        }
    }
}
