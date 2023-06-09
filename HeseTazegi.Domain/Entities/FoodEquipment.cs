using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeseTazegi.Domain.Entities
{
    public class FoodEquipment
    {
        public int FoodId { get; set; }
        public int EquipmentId { get; set; }

        public FoodEquipment(int foodId, int equipmentId)
        {
            FoodId = foodId;
            EquipmentId = equipmentId;
        }

        public Food Food { get; set; }
        public Equipment Equipment { get; set; }
    }
}
