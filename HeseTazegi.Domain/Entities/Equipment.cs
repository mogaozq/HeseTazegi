using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeseTazegi.Domain.Entities
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Equipment(string name)
        {
            Name = name;
        }

        public ICollection<FoodEquipment> FoodEquipments { get; set; }

    }
}
