using Squeeze.Models.DTO;
using Squeeze.Models;

namespace Squeeze.Mapper
{
    public static class KundeMapper
    {
        public static KundeDTO ToDTO(Kunde kunde)
        {
            return new KundeDTO
            {
                KundeId = kunde.KundeId,
                Navn = kunde.Navn,
                Epost = kunde.Epost,
                Telefon = kunde.Telefon
            };
        }

        public static Kunde FromDTO(KundeDTO dto)
        {
            return new Kunde
            {
                KundeId = dto.KundeId,
                Navn = dto.Navn,
                Epost = dto.Epost,
                Telefon = dto.Telefon
            };
        }
    }
}
