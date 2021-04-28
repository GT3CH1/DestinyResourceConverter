using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DestinyConverter
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCreateXML()
        {
            CsvReader reader = new CsvReader();
            reader.CreateExportXML("..\\..\\..\\..\\Resources\\import.csv",true,true,"0000",reader.DestinyItems[0]);
            Assert.IsTrue(File.Exists(@"..\..\..\..\Resources\test.xml"));
        }
    }
}