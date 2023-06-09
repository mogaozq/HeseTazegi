using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeseTazegi.Domain.Entities
{
    public class UserAllergicIngredient
    {
        public int UserId { get; set; }

        public int IngredientId { get; set; }

        public UserAllergicIngredient(int userId, int ingredientId)
        {
            UserId = userId;
            IngredientId = ingredientId;
        }

        public User User { get; set; }
        public Ingredient Ingredient{ get; set; }
    }
}
