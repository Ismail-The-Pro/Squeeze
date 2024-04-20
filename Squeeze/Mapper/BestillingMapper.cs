using Squeeze.Mapper;

public static class BestillingMapper
{
    public static BestillingDTO ToDTO(Bestilling bestilling)
    {
        return new BestillingDTO
        {
            BestillingId = bestilling.BestillingId,
            Bestillingsdato = bestilling.Bestillingsdato,
            Status = bestilling.Status,
            TotalPris = bestilling.TotalPris,
            
        };
    }

    public static Bestilling FromDTO(BestillingDTO dto)
    {
        return new Bestilling
        {
            BestillingId = dto.BestillingId,
            KundeId = dto.KundeId,
            Bestillingsdato = dto.Bestillingsdato,
            Status = dto.Status,
            TotalPris = dto.TotalPris,
            
        };
    }
}


