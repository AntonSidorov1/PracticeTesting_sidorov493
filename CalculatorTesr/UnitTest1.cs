using Microsoft.VisualStudio.TestTools.UnitTesting;
using WSUniversalLib;
using System;

namespace CalculatorTesr
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Результат расчётов без использования метода совпадает с результатом рассчётов без использования метода
        /// </summary>
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

        /// <summary>
        /// Для 15 единиц продукции шириной 20 и длиной 15, где количества материала на 1 единицу требуется 8,43 с процентом деффекта 0.03, требуется 114147 единиц материала
        /// </summary>
        [TestMethod]
        public void For15ProductUnits20WidthAnd45LongProductType8And43MaterialType03TheMaterialQuantityIs114147()
        {
            float productType = 8.43f;
            float materialType = 0.003f;
            int count = 15;
            float width = 20;
            float length = 45;
            
            int materialCount = Calculation.GetQuantityForProduct(productType, materialType, count, width, length);
            Assert.AreEqual(114147, materialCount, 0.001, materialCount + "!=" + 114147);
        }

        /// <summary>
        /// для тестирования случая передачи несуществующего типа продукции.
        /// </summary>
        [TestMethod]
        public void GetQuantityForProduct_NonExistentProductType()
        {


            try
            {
                int materialCount = Calculation.GetQuantityForProduct(4, 2, 12, 14, 34);
                Assert.AreEqual(114147, materialCount, 0.001, materialCount + "!=" + 114147);
            }
            catch (Exception e)
            {
                NullReferenceException ex = new NullReferenceException();
                Assert.AreEqual(ex.Message, e.Message);
            }
        }


        /// <summary>
        /// Для 5 единиц продукции 1 типа шириной 4 и длиной 2 материала 2 типа требуется 45 единиц материала
        /// </summary>
        [TestMethod]
        public void For5UnitsOfProductType1WithAWidthOf4AndALengthOf2MaterialsOfType2Is45UnitsOfMaterialAreRequired()
        {


            try
            {
                int materialCount = Calculation.GetQuantityForProduct(1, 2, 4, 2, 5);
                Assert.AreEqual(45, materialCount, 0.001, materialCount + "!=" + 45);
            }
            catch (Exception e)
            {
                NullReferenceException ex = new NullReferenceException();
                Assert.AreEqual(ex.Message, e.Message);
            }
        }

        /// <summary>
        /// Для 50 единиц продукции 3 типа шириной 40 и длиной 80 материала 1 типа требуется 1352847 единиц материала
        /// </summary>
        [TestMethod]
        public void For50UnitsOfProduct3TypesWithAWidthOf40AndALengthOf80MaterialOfType1Is1352847UnitsOfMaterialAreRequired()
        {


            try
            {
                int materialCount = Calculation.GetQuantityForProduct(3, 1, 40, 80, 50);
                Assert.AreEqual(1352847, materialCount, 0.001, materialCount + "!=" + 1352847);
            }
            catch (Exception e)
            {
                NullReferenceException ex = new NullReferenceException();
                Assert.AreEqual(ex.Message, e.Message);
            }
        }

        /// <summary>
        /// Для 150 единиц продукции 2 типа шириной 25 и длиной 75 материала 2 типа требуется 703969 единиц материала
        /// </summary>
        [TestMethod]
        public void For150UnitsOfProductType2WithAWidthOf25AndALengthOf75MaterialOfType2Is703969UnitsOfMaterialAreRequired()
        {


            try
            {
                int materialCount = Calculation.GetQuantityForProduct(2, 2, 25, 75, 150);
                Assert.AreEqual(703969, materialCount, 0.001, materialCount + "!=" + 703969);
            }
            catch (Exception e)
            {
                NullReferenceException ex = new NullReferenceException();
                Assert.AreEqual(ex.Message, e.Message);
            }
        }


        /// <summary>
        /// Получить количество материала при несуществующем типе материала
        /// </summary>
        [TestMethod]
        public void GetQuantityOfMaterialWhenMaterialTypeDoesNotExist()
        {

            try
            { 
           
                int materialCount = Calculation.GetQuantityForProduct(2, 12, 12, 14, 34);
                Assert.AreEqual(114147, materialCount, 0.001, materialCount + "!=" + 114147);
            }
            catch (Exception e)
            {
                NullReferenceException ex = new NullReferenceException();
                Assert.AreEqual(ex.Message, e.Message);
            }
        }

        /// <summary>
        /// Получить количество материала, если тип продукции - текст
        /// </summary>
        [TestMethod]
        public void GetMaterialQuantityIfproductTypeIsText()
        {
            try
            {


                int materialCount = Calculation.GetQuantityForProduct(Convert.ToInt32("abc"), 12, 12, 14, 34);
                Assert.AreEqual(114147, materialCount, 0.001, materialCount + "!=" + 114147);
            }
            catch (Exception e)
            {
                FormatException ex = new FormatException("Входная строка имела неверный формат.");
                Assert.AreEqual(ex.Message, e.Message);
            }
        }

        /// <summary>
        /// Получить количество материала, если тип продукции - Не целое число
        /// </summary>
        [TestMethod]
        public void GetMaterialQuantityIfProductTypeIsNotAnInteger()
        {
                try
                {


                    int materialCount = Calculation.GetQuantityForProduct(Convert.ToInt32(5.12.ToString()), 12, 12, 14, 34);
            Assert.AreEqual(114147, materialCount, 0.001, materialCount + "!=" + 114147);
            }
            catch (Exception e)
            {
                FormatException ex = new FormatException("Входная строка имела неверный формат.");
                Assert.AreEqual(ex.Message, e.Message);
            }
        }


        /// <summary>
        /// Получить количество материала при отрицательном значении количества продукции, длины или ширины
        /// </summary>
        [TestMethod]
        public void GetMaterialQuantityWhenProductQuantityOrLengthOrWidthIsNegative()
        {
            ArgumentException ex = new ArgumentException();
            try
            {


                int materialCount = Calculation.GetQuantityForProduct(1, 1, -12, -14, -34);
                Assert.AreEqual(ex.Message, materialCount);
            }
            catch (Exception e)
            {
                //ArgumentException ex = new ArgumentException();
                Assert.AreEqual(ex.Message, e.Message);
            }
        }


    }
}
