using System.IO;
using NUnit.Framework;
using TransactionImport;

namespace TransactionImportTest
{
    public class Tests
    {
        private string _cakeExportFile = @"D:\Projekte\CoinPortfolio\TransactionImportTest\testfiles\BTC_EXPORT.csv";
        
  //      [SetUp]
  //      public void Setup()
  //      {
  //      }

        [Test]
        public void CakeConverterTest()
        {
            CakeConverter converter = new CakeConverter();
            using (FileStream fs = File.OpenRead(_cakeExportFile))
            {
                converter.Convert(fs);
            }

            Assert.Pass();
        }
    }
}