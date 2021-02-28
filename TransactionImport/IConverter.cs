using System.IO;

namespace TransactionImport
{
    public interface IConverter
    {
        public void Convert(FileStream fileStream);
    }
}