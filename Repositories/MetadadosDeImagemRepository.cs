using ChallengeAPI.Interfaces;
using ChallengeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ChallengeAPI.Repositories
{
    public class MetadadosDeImagemRepository : IMetadadosDeImagemRepository
    {
        private readonly MetadadosDeImagemContext _context;
        public MetadadosDeImagemRepository(MetadadosDeImagemContext metadadosDeImagemContext)
        {
            _context = metadadosDeImagemContext;
        }

        public  async Task<List<MetadadosDeImagem>?> Get()
        {
            return await _context.MetadadosDeImagens.ToListAsync();
        }

        public async Task<MetadadosDeImagem?> GetById(int id)
        {
            var metadados = await _context.MetadadosDeImagens.FindAsync(id);
            return metadados;
        }

        public async Task<bool> ExisteNaBase(string nomeDoArquivo)
        {
            return await _context.MetadadosDeImagens.AnyAsync(m => m.NomeDoArquivo == nomeDoArquivo);
        }

        public async Task<MetadadosDeImagem> Adicionar(MetadadosDeImagem metadados)
        {
           MetadadosDeImagem metadadosAdicionado =  _context.MetadadosDeImagens.Add(metadados).Entity;
           await _context.SaveChangesAsync();
            return metadadosAdicionado;
        }
    }
}
