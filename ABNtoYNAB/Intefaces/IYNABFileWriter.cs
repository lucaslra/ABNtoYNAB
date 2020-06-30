using System.Collections.Generic;
using System.Threading.Tasks;
using ABNtoYNAB.BL.Models;

namespace ABNtoYNAB.BL.Interfaces
{
    public interface IYNABFileWriter
    {
        Task WriteRecordsAsync(IEnumerable<ImportRow> importRows);
        void WriteRecords(IEnumerable<ImportRow> importRows);
    }
}
