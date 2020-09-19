using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using ApiJogame_EFC.Domains;
using ApiJogame_EFC.Interfaces;
using ApiJogame_EFC.Repositories;
using ApiJogame_EFC.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiJogame_EFC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly IJogoRepository _jogoRepository;

        public JogosController()
        {
            _jogoRepository = new JogoRepository();
        }

        // GET: api/<JogosController>
        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns>Lista de jogos</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var jogos = _jogoRepository.Listar();

                if (jogos.Count == 0)
                    return NoContent();

                return Ok(jogos);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/<JogosController>
        /// <summary>
        /// Busca um jogo por ID
        /// </summary>
        /// <param name="id">ID do jogo</param>
        /// <returns>Jogo buscado pelo ID</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var jogos = _jogoRepository.BuscarPorId(id);

                if (jogos == null)
                    return NotFound();

                return Ok(jogos);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/jogos
        /// <summary>
        /// Cadastra um jogo
        /// </summary>
        /// <param name="jogo">Objeto jogo a ser cadastrado</param>
        /// <returns>Jogo cadastrado</returns>
        [HttpPost]
        public IActionResult Post(Jogo jogo)
        {
            try
            {
                if(jogo.Imagem == null)
                {
                    var urlImagem = Upload.Local(jogo.Imagem);

                    jogo.UrlImagem = urlImagem;
                }

                //Adiciona um novo jogo
                _jogoRepository.Adicionar(jogo);

                //Retorna Ok caso o jogo tenha sido cadastrado
                return Ok(jogo);
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro retorno BadRequest e a mensagem da exception
                return BadRequest(ex.Message);
            }
        }
        // PUT api/jogos/5
        /// <summary>
        /// Edita um jogo
        /// </summary>
        /// <param name="id">ID do jogo a ser editado</param>
        /// <param name="jogo">Objeto jogo a ser editado</param>
        /// <returns>Jogo editado</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Jogo jogo)
        {
            try
            {
                //Edita o jogo
                _jogoRepository.Editar(jogo);

                //Retorna com ok os dados do jogo
                return Ok(jogo);
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro retorno BadRequest e a mensagem da exception
                return BadRequest(ex.Message);
            }
        }


        // DELETE api/jogos/5
        /// <summary>
        /// Deleta um jogo
        /// </summary>
        /// <param name="id">ID do jogo</param>
        /// <returns>Jogo deletado</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                //Busca o jogo pelo Id
                var jogo = _jogoRepository.BuscarPorId(id);

                //Verifica se o jogo existe
                //Caso não exista retorna NotFound
                if (jogo == null)
                    return NotFound();

                //Caso exista remove o jogo
                _jogoRepository.Remover(id);
                //Retorna Ok
                return Ok(id);
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro retorno BadRequest e a mensagem da exception
                return BadRequest(ex.Message);
            }
        }
    }
}
