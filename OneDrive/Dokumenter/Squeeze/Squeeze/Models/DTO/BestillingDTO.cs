namespace Sqyeeze.Models.DTO
{
    public class BestillingDTO
    {
        public int BestillingId { get; set; }
        public int KundeId { get; set; }  // Add this line to include the KundeId
        public DateTime Bestillingsdato { get; set; }
        public string Status { get; set; }
        public decimal TotalPris { get; set; }

    }
}