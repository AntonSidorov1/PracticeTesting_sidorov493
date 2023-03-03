using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSUniversalLib
{
    public class Product
    {
        private int productType = 1;
        public int ProductType
        {
            get => productType;
            set => productType = value;
        }

        private float materialCount = 1.1f;
        public float MaterialCount
        {
            get => materialCount;
            set => materialCount = value;
        }

        public Product(int productType, float materialCount): this(productType)
        {
            MaterialCount = materialCount;
        }

        public Product(int productType) : this()
        {
            ProductType = productType;
        }

        public Product()
        {

        }
    }
}
