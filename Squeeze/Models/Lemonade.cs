using System.ComponentModel.DataAnnotations;

public class Lemonade
{
    [Key]
    public int LemonadeId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public bool IsAvailable { get; set; }
}
