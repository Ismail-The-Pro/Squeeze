namespace Squeeze.Models
{
    public class Produkt
    {
        public int ProduktId { get; set; }
        public string Navn { get; set; }
        public string Beskrivelse { get; set; }
        public decimal Pris { get; set; }
        public bool Tilgjengelig { get; set; }
    }


}
