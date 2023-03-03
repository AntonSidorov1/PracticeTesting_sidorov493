using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSUniversalLib
{
    public class Calculation
    {
        static List<Product> products = new List<Product>(new Product[] { new Product(1, 1.1f), new Product(2, 2.5f), new Product(3, 8.43f) });
        static List<Material> materials = new List<Material>(new Material[] {new Material(1, 0.3f), new Material(2, 0.12f) });

        public static int GetQuantityForProduct(float productType, float materialType, int count, float width, float length)
        {
            float materialCount = productType * width * length;
            materialCount *= count;
            materialCount += (materialCount * materialType);
            float materialCount1 = (float)Math.Round(materialCount);
            //materialCount = (float)Math.Round(materialCount, MidpointRounding.AwayFromZero);
            materialCount = materialCount1 >= materialCount ? materialCount1 : materialCount1 + 1;

            return (int)materialCount;
        }

        public static int GetQuantityForProduct(int productType, int materialType, int count, float width, float length)
        {
            Product product = products.Find(p => p.ProductType == productType);
            Material material = materials.Find(p => p.MaterialType == materialType);
            return GetQuantityForProduct(product.MaterialCount, material.Defect, count, width, length);
        }
    }
}
