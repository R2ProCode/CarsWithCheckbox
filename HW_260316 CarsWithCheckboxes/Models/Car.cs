namespace HW_260316_CarsWithCheckboxes.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public CarType CarType { get; set; }
        public bool HasLeatherSeats { get; set; }
    }
}
