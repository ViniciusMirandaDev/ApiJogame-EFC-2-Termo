using System;
using System.Collections.Generic;
using System.Linq;
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
    public class JogadoresController : ControllerBase
    {
        private readonly IJogadorRepository _jogadorRepository;

        public JogadoresController()
        {
            _jogadorRepository = new JogadorRepository();
        }

        // GET: api/<JogosController>
        /// <summary>
        /// Lista todos os jogadores
        /// </summary>
        /// <returns>Lista de jogadores</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var jogadores = _jogadorRepository.Listar();

                if (jogadores.Count == 0)
                    return NoContent();

                return Ok(jogadores);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/<JogadoresController>
        /// <summary>
        /// Busca um jogador por ID
        /// </summary>
        /// <param name="id">ID do jogador</param>
        /// <returns>Jogador buscado pelo ID</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var jogadores = _jogadorRepository.BuscarPorId(id);

                if (jogadores == null)
                    return NotFound();

                return Ok(jogadores);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/jogadores
        /// <summary>
        /// Cadastra um jogador
        /// </summary>
        /// <param name="jogador">Objeto jogador a ser cadastrado</param>
        /// <returns>Jogador cadastrado</returns>
        [HttpPost]
        public IActionResult Post(Jogador jogador)
        {
            try
            {
                if (jogador.Imagem == null)
                {
                    var urlImagem = Upload.Local(jogador.Imagem);

                    jogador.UrlImagem = urlImagem;
                }

                //Adiciona um novo jogador
                _jogadorRepository.Adicionar(jogador);

                //Retorna Ok caso o jogo tenha sido cadastrado
                return Ok(jogador);
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro retorno BadRequest e a mensagem da exception
                return BadRequest(ex.Message);
            }
        }
        // PUT api/jogador/5
        /// <summary>
        /// Edita um jogador
        /// </summary>
        /// <param name="id">ID do jogador a ser editado</param>
        /// <param name="jogador">Objeto jogador a ser editado</param>
        /// <returns>Jogo editado</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Jogador jogador)
        {
            try
            {
                //Edita o jogador
                _jogadorRepository.Editar(jogador);

                //Retorna com ok os dados do jogador
                return Ok(jogador);
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro retorno BadRequest e a mensagem da exception
                return BadRequest(ex.Message);
            }
        }


        // DELETE api/jogador/5
        /// <summary>
        /// Deleta um jogador
        /// </summary>
        /// <param name="id">ID do jogador</param>
        /// <returns>Jogador deletado</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                //Busca o jogador pelo Id
                var jogador = _jogadorRepository.BuscarPorId(id);

                //Verifica se o jogador existe
                //Caso não exista retorna NotFound
                if (jogador == null)
                    return NotFound();

                //Caso exista remove o jogador
                _jogadorRepository.Remover(id);
                //Retorna Ok
                return Ok(id);
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro retorno BadRequest e a mensagem da exception
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Post(List<JogosJogadores> jogadoresJogos)
        {
            try
            {
                //Adiciona um jogo ao jogador
                Jogador jogador = _jogadorRepository.AdicionarJogo(jogadoresJogos);

                return Ok(jogador);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
