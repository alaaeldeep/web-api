using WebApplication1.Validations;

namespace WebApplication1.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string? Model { get; set; } 
        public int price { get; set; }

        [Datemustbeinpast]
        public DateTime ProductionDate { get; set; }
        public string type { get; set; } = string.Empty;
    }
}
