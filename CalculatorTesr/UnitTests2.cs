using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WSUniversalLib;

namespace CalculatorTesr
{
    [TestClass]
    class UnitTests2
    {

        [TestMethod]
        public void GetQuantityForProduct_NonExistentProductType()
        {
            

            int materialCount = Calculation.GetQuantityForProduct(4, 2, 12, 14, 34);
            Assert.AreEqual(114147, materialCount, 0.001, materialCount + "!=" + 114147);
        }

    }
}
