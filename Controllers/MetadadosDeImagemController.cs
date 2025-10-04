using ChallengeAPI.Interfaces;
using ChallengeAPI.Models;
using ChallengeAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeAPI.Controllers
{
    [Route("api/[controller]")]
    public class MetadadosDeImagemController : ControllerBase
    {
        private readonly IMetadadosDeImagemService _metadadosDeImagemService;

        public MetadadosDeImagemController(IMetadadosDeImagemService metadadosDeImagemService)
        {
            _metadadosDeImagemService = metadadosDeImagemService;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<MetadadosDeImagem>> Get()
        {

            return Ok(_metadadosDeImagemService.Get());
        }

        [HttpGet]
        [Route("/{id:int}")]
        public ActionResult<List<MetadadosDeImagem>> Get(int id)
        {

            return Ok();
        }


        [HttpPost]
        [Route("")]
        public IActionResult Post(IFormFile Imagem)
        {

            try
            {
                _metadadosDeImagemService.CriarMetadadosDaImagem(Imagem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut]
        [Route("/{id:int}")]
        public IActionResult Put(int id, IFormFile Imagem)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("/{id:int}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
