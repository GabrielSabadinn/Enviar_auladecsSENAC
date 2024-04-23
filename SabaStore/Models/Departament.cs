namespace SabaStore.Models
{
    public class Departament
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public List<Seller> Sellers { get; set; } = new List<Seller>();

    }
}
