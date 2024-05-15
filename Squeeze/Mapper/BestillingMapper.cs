using Squeeze.Mapper;

public static class BestillingMapper
{
    public static BestillingDTO ToDTO(Bestilling bestilling)
    {
        if (bestilling == null) return null;
        return new BestillingDTO
        {
            BestillingId = bestilling.BestillingId,
            KundeId = bestilling.KundeId,
            Bestillingsdato = bestilling.Bestillingsdato,
            Status = bestilling.Status,
            TotalPris = bestilling.TotalPris
        };
    }

    public static Bestilling ToEntity(BestillingDTO dto)
    {
        if (dto == null) return null;
        return new Bestilling
        {
            BestillingId = dto.BestillingId,
            KundeId = dto.KundeId,
            Bestillingsdato = dto.Bestillingsdato,
            Status = dto.Status,
            TotalPris = dto.TotalPris
        };
    }
}



