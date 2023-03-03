using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSUniversalLib
{
    public class Material : Product
    {
        public Material()
        {
            MaterialCount = 0;
        }

        public Material(int materialType) : base(materialType)
        {
            MaterialCount = 0;
        }

        public Material(int materialType, float materialDeffect) : this(materialType)
        {
            DefectPersent = materialDeffect;
        }

        public int MaterialType
        {
            get => ProductType;
            set => ProductType = value;
        }

        private float defectPersent = 0.3f;

        public float DefectPersent
        {
            get => defectPersent;
            set => defectPersent = value;
        }

        public float Defect
        {
            get => defectPersent / 100f;
            set => defectPersent = value * 100f;
        }
    }
}
