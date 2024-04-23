namespace SabaStore.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime birthDate { get; set; }
        public double Salary { get; set; }

        public int DepertamentId { get; set; }

        public Departament Departament { get; set; }

        public List<SalesRecord> Sales { get; set; } = new List<SalesRecord>(); 

    }
}
