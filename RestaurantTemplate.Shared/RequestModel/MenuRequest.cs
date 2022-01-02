using System.Collections.Generic;

namespace RestaurantTemplate.Shared.RequestModel
{
    public class MenuRequest
    {
        public string Name { get; set; }
        public string Category { get; set; }

        public List<string> Ingredients { get; set; }
        public List<string> Allergens { get; set; }

        public double Price { get; set; }
    }
}
