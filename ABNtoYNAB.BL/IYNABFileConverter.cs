using System.Threading.Tasks;

namespace ABNtoYNAB.BL
{
    public interface IYNABFileConverter
    {
        Task ExportAsYNAB();
    }
}
