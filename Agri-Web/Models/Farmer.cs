using Agri_Web.Models;

namespace AgriWeb.Models
{
    public class Farmer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactInfo { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
