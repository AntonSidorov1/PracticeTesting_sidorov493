using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSUniversalLib
{
    public class Calculation
    {
        public int GetQuantityForProduct(int productType, int materialType, int count, float width, float length)
        {
            float materialCount = productType * width * length;
            materialCount *= count;
            materialCount += (materialCount * materialType);
            float materialCount1 = (float)Math.Round(materialCount);
            materialCount1 = materialCount1 >= materialCount ? materialCount1 : materialCount1 + 1;

            return (int)materialCount;
        }
    }
}
