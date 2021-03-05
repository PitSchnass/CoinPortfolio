using System.Collections.Generic;
using System.IO;
using Common;

namespace TransactionImport
{
    public interface IConverter
    {
        public List<CoinTransaction> Convert(FileStream fileStream);
    }
}