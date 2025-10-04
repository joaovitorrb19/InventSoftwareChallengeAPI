using ChallengeAPI.Models;

namespace ChallengeAPI.Interfaces
{
    public interface IMetadadosDeImagemRepository
    {
        public Task<bool> ExisteNaBase(string nomeDoArquivo);
        public Task<List<MetadadosDeImagem>?> Get();
        public Task<MetadadosDeImagem?> GetById(int id);
        public Task<MetadadosDeImagem> Adicionar(MetadadosDeImagem metadados);
    }
}
