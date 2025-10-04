using ChallengeAPI.Models;

namespace ChallengeAPI.Interfaces
{
    public interface IMetadadosDeImagemService
    {

        public Task<List<MetadadosDeImagem>?> Get();
        public Task<MetadadosDeImagem> CriarMetadadosDaImagem(IFormFile File);

        public Task ValidarExtensaoDoArquivo(string extensao);

        public Task<MetadadosDeImagem> AdicionarMetadadosDeImagem(IFormFile file);

        public Task<string> CalcularProporcao(int altura, int largura);
    }
}
