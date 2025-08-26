namespace CarWorkshop.Application.CarWorkshop
{
    public class CarWorkshopServiceDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public decimal Price { get; set; }

        public int CarWorkshopId { get; set; }
    }
}
