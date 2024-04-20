using Squeeze.Models.DTO;

namespace Squeeze.Mapper
{
    public static class LemonadeMapper
    {
        public static LemonadeDTO ToDTO(Lemonade lemonade)
        {
            return new LemonadeDTO
            {
                LemonadeId = lemonade.LemonadeId,
                Navn = lemonade.Name,
                Pris = lemonade.Price,
                Tilgjengelig = lemonade.IsAvailable
            };
        }

        public static Lemonade FromDTO(LemonadeDTO dto)
        {
            return new Lemonade
            {
                LemonadeId = dto.LemonadeId,
                Name = dto.Navn,
                Price = dto.Pris,
                IsAvailable = dto.Tilgjengelig
            };
        }
    }


}
