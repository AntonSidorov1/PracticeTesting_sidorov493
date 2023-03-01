using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WSUniversalLib;

namespace CalculationTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TheResultCalculatedWithoutApplyingThisMethodCoincidesWithTheResultCalculatedUsingTheMethod()
        {
            float productType = 8.43f;
            float materialType = 0.003f;
            int count = 15;
            float width = 20;
            float length = 45;
            float materialCount = productType * width * length;
            materialCount *= count;
            materialCount += (materialCount * materialType);

            float materialCount4 = materialCount;
            float materialCount1 = (float)Math.Round(materialCount);
            materialCount = materialCount1 >= materialCount ? materialCount1 : materialCount1 + 1;
            //materialCount = (float)Math.Round(materialCount, MidpointRounding.AwayFromZero);

            int materialCount2 = (int)materialCount;
            int materialCount3 = Calculation.GetQuantityForProduct(productType, materialType, count, width, length);
            Assert.AreEqual(materialCount2, materialCount3, 0.001, materialCount2 + $"({materialCount4})" + "!=" + materialCount3);
        }
    }
}
