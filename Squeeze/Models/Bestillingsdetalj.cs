using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Bestillingsdetalj
{
    [Key]
    public int BestillingsdetaljId { get; set; }
    [ForeignKey("Bestilling")]
    public int BestillingId { get; set; }
    [ForeignKey("Lemonade")]
    public int LemonadeId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string Customizations { get; set; }
    public virtual Lemonade Lemonade { get; set; }
}
