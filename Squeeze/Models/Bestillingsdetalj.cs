using Squeeze.Models;

public class Bestillingsdetalj
{
    public int BestillingsdetaljId { get; set; } // Unik identifikator for bestillingsdetaljen (primærnøkkel)
    public int BestillingId { get; set; } // Identifikator som refererer til bestillingen (fremmednøkkel)
    public int ProduktId { get; set; }// Identifikator for produktet som er bestilt (fremmednøkkel)

    public Produkt Produkt { get; set; }
    public int Antall { get; set; } // Antall av produktet som er bestilt
    public decimal Pris { get; set; } // Prisen på produktet på bestillingstidspunktet
    public string Tilpasninger { get; set; } // Eventuelle tilpasninger ønsket av kunden (f.eks., mindre sukker, ekstra smak)
}
