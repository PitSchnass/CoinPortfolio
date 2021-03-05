using System;
using System.IO;
using Common.Enums;
using NUnit.Framework;
using TransactionImport;

namespace TransactionImportTest
{
    public class Tests
    {
        private string _cakeExportFileBTC = @"D:\Projekte\CoinPortfolio\TransactionImportTest\testfiles\BTC_EXPORT.csv";
        private string _cakeExportFileDFI = @"D:\Projekte\CoinPortfolio\TransactionImportTest\testfiles\DFI_EXPORT.csv";
        
  //      [SetUp]
  //      public void Setup()
  //      {
  //      }

        [Test]
        public void CakeConverterTest()
        {
            CakeConverter converter = new CakeConverter();
            using (FileStream fs = File.OpenRead(_cakeExportFileBTC))
            {
                var transactions = converter.Convert(fs);
                
                Console.WriteLine(transactions.Count + " BTC transactions where converted.");
                
                if (transactions.Exists(_ => _.Operation == (int)TransactionOperation.Invalid))
                   Assert.Fail("Invalid operations exist. Not all Cake operations could be matched"); 
            }

            using (FileStream fs = File.OpenRead(_cakeExportFileDFI))
            {
                var transactions = converter.Convert(fs);
                
                Console.WriteLine(transactions.Count + " DFI transactions where converted.");
                
                if (transactions.Exists(_ => _.Operation == (int)TransactionOperation.Invalid))
                    Assert.Fail("Invalid operations exist. Not all Cake operations could be matched");
            }
            
            Assert.Pass();
        }
    }
}