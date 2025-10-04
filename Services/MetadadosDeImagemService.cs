using ChallengeAPI.Interfaces;
using ChallengeAPI.Models;
using SixLabors.ImageSharp;

namespace ChallengeAPI.Services
{
    public class MetadadosDeImagemService : IMetadadosDeImagemService
    {
        private readonly IMetadadosDeImagemRepository _metadadosDeImagemRepository;

        public MetadadosDeImagemService(IMetadadosDeImagemRepository metadadosDeImagemRepository)
        {
            _metadadosDeImagemRepository = metadadosDeImagemRepository;
        }

        public async Task<List<MetadadosDeImagem>?> Get()
        {
            var metadados = await _metadadosDeImagemRepository.Get();
            return metadados;
        }

        public async Task<MetadadosDeImagem> CriarMetadadosDaImagem(IFormFile File)
        {

            ValidarExtensaoDoArquivo(File.ContentType);

            if (_metadadosDeImagemRepository.ExisteNaBase(File.FileName).Result == true)
                throw new Exception("Já existe um arquivo com esse nome na base de dados.");

            var imagem = await _metadadosDeImagemRepository.Adicionar(AdicionarMetadadosDeImagem(File));
            return imagem;
        }

        public async Task ValidarExtensaoDoArquivo(string extensao)
        {
            List<String> extensoes = new List<String>() { "image/png", "image/jpeg", "image/jpg", "image/gif", "image/bmp" };

            if (!extensoes.Contains(extensao.ToLower()))
                throw new Exception("Extensão de arquivo inválida. As extensões permitidas são: .png, .jpeg, .jpg, .gif, .bmp");
 
        }

        public async Task<MetadadosDeImagem> AdicionarMetadadosDeImagem(IFormFile file)
        {

            // using fecha o stream automaticamente
            using Stream stream = file.OpenReadStream();

            Image image = SixLabors.ImageSharp.Image.Load(stream);

                if((image.Height == 0 || image.Width == 0) || (image.Height < 0 || image.Width < 0))
                        throw new Exception("Dimensoes Inválidas");

            return new MetadadosDeImagem
            {
                NomeDoArquivo = file.FileName,
                TipoDoArquivo = file.ContentType,
                Altura = image.Height,
                Comprimento = image.Width,
                Proporcao = CalcularProporcao(image.Height, image.Width),
                DataDeCriacao = DateTime.Now
            };
           
        }

        public async Task<string> CalcularProporcao(int altura, int largura)
        {
            List<int> divisores = new List<int>();

            int numero01 = altura;
            int numero02 = largura;

            int menorNumero = Math.Min(numero01, numero02);

            for (int i = 1; i <= menorNumero; i++)
            {
                if (numero01 % i == 0 && numero02 % i == 0)
                {
                    divisores.Add(i);
                    continue;
                }

            }

            int maiorDivisor = divisores.Max();


            if (maiorDivisor == 1)
            {
                return $"{numero01}:{numero02} ≈ {Math.Round((double)numero01 / numero02, 2)}";
            }

            int proporcaoNumero01 = numero01 / maiorDivisor;
            int proporcaoNumero02 = numero02 / maiorDivisor;

            return $"{numero01}:{numero02} = {proporcaoNumero01}:{proporcaoNumero02}";
        }


    }
}

