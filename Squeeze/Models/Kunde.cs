namespace Squeeze.Models
{
    
    public class Kunde
    {
        public int KundeId { get; set; } // Unik identifikator for kunden (primærnøkkel)
        public string Navn { get; set; } // Kundens navn
        public string Epost { get; set; } // Kundens e-postadresse
        public string Telefon { get; set; } // Kundens telefonnummer
        public int Lojalitetspoeng { get; set; } // Poeng som brukes for lojalitetsrabatter
    }

}
