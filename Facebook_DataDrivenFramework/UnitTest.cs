using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook_DataDrivenFramework
{
    class UnitTest:Base.BaseClass
    {
        [Test]
        public void ReadingData()
        {
            ExcelOperations.PopulateInCollection(@"C:\Users\girish.v\source\repos\Facebook_DataDrivenFramework\Facebook_DataDrivenFramework\ExcelData\TestData.xlsx");
        }
    }
}
