namespace Squeeze.Models
{
    // Fil: Models/Bestilling.cs
    public class Bestilling
    {
        public int BestillingId { get; set; } // Unik identifikator for bestillingen (primærnøkkel)
        public int KundeId { get; set; } // Identifikator som refererer til kunden som la inn bestillingen (fremmednøkkel)
        public DateTime Bestillingsdato { get; set; } // Dato og tidspunkt for når bestillingen ble lagt inn
        public string Status { get; set; } // Status for bestillingen (f.eks., "Ny", "Under Behandling", "Klar", "Utlevert")
        public decimal TotalPris { get; set; } // Den totale prisen for bestillingen
        public List<Bestillingsdetalj> Bestillingsdetaljer { get; set; } // En liste over elementer i bestillingen
    }

}
