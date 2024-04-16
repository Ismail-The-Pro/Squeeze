using System.ComponentModel.DataAnnotations;

namespace Squeeze.Models
{
    public class Kunde
    {
        [Key]
        public int KundeId { get; set; }
        [Required, MaxLength(100)]
        public string Navn { get; set; }
        [EmailAddress]
        public string Epost { get; set; }
        [Phone]
        public string Telefon { get; set; }
    }
}