using System.Collections.Generic;
using ABNtoYNAB.BL.Models;

namespace ABNtoYNAB.BL.Interfaces
{
    public interface IYNABFileReader
    {
        IEnumerable<ImportRow> GetRecords(string filePath);
    }
}
