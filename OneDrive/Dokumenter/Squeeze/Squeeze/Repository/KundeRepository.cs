using Microsoft.EntityFrameworkCore;
using Squeeze.Mapper;
using Squeeze.Models;
using Squeeze.Models.DTO;
using System.Data.Entity;

namespace Squeeze.Repository
{

    public class KundeRepository : IKundeRepository
    {
        private readonly AppDbContext _context;

        public KundeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Kunde> AddAsync(Kunde kunde)
        {
            await _context.Kunder.AddAsync(kunde);
            await _context.SaveChangesAsync();
            return kunde;
        }

        public async Task<KundeDTO> CreateKundeAsync(KundeDTO kundeDto)
        {
            var kunde = new Kunde { Navn = kundeDto.Navn, Epost = kundeDto.Epost, Telefon = kundeDto.Telefon };
            _context.Kunder.Add(kunde);
            await _context.SaveChangesAsync();
            kundeDto.KundeId = kunde.KundeId; // Oppdaterer KundeId til den tildelte verdien etter lagring
            return kundeDto;
        }

        public async Task DeleteKundeAsync(int id)
        {
            var kunde = await _context.Kunder.FindAsync(id);
            if (kunde != null)
            {
                _context.Kunder.Remove(kunde);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IQueryable<Kunde>> GetAllKunderAsync()
        {
            return _context.Kunder.AsQueryable();
        }

        public async Task<KundeDTO> GetKundeByIdAsync(int id)
        {
            var kunde = await _context.Kunder.FindAsync(id);
            if (kunde == null) return null;
            return new KundeDTO { KundeId = kunde.KundeId, Navn = kunde.Navn, Epost = kunde.Epost, Telefon = kunde.Telefon };
        }

        public async Task UpdateKundeAsync(KundeDTO kundeDto)
        {
            var kunde = await _context.Kunder.FindAsync(kundeDto.KundeId);

            if (kunde != null)
            {
                kunde.Navn = kundeDto.Navn;
                kunde.Epost = kundeDto.Epost;
                kunde.Telefon = kundeDto.Telefon;

                _context.Kunder.Update(kunde);
                await _context.SaveChangesAsync();
            }
        }
        
    }

}