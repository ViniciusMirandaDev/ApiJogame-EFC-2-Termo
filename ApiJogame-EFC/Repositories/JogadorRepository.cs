using ApiJogame_EFC.Contexts;
using ApiJogame_EFC.Domains;
using ApiJogame_EFC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiJogame_EFC.Repositories
{
    public class JogadorRepository : IJogadorRepository
    {
        private readonly JogadorContext _ctx;
        public JogadorRepository()
        {
            _ctx = new JogadorContext();
        }

        #region Leitura
        /// <summary>
        /// Busca um jogador por seu ID
        /// </summary>
        /// <param name="id">Id do jogador</param>
        /// <returns>Jogador buscado por ID</returns>
        public Jogador BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Jogadores.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Lista todos os jogadores 
        /// </summary>
        /// <returns>Lista de jogadores</returns>
        public List<Jogador> Listar()
        {
            try
            {
                return _ctx.Jogadores.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Gravação
        /// <summary>
        /// Adiciona um novo jogador
        /// </summary>
        /// <param name="jogador">Objeto jogador a ser criado</param>
        public void Adicionar(Jogador jogador)
        {
            try
            {
                _ctx.Jogadores.Add(jogador);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Adiciona um jogo ao jogador
        /// </summary>
        /// <param name="jogosJogador">Lista de jogos do jogador</param>
        /// <returns>Jogo adicionado ao jogador</returns>
        public Jogador AdicionarJogo(List<JogosJogadores> jogosJogador)
        {
            try
            {
                Jogador _jogador = new Jogador { JogadorJogos = new List<Jogo>()};
                
                foreach(var jogo in jogosJogador)
                {
                    jogo.IdJogador = _jogador.Id;
                    jogo.IdJogo = jogo.IdJogo;
                }

                _ctx.Jogadores.Add(_jogador);
                _ctx.SaveChanges();
                return _jogador;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Edita um jogador
        /// </summary>
        /// <param name="jogador">Jogador a ser editado</param>
        public void Editar(Jogador jogador)
        {
            try
            {
                Jogador jogadorTemp = BuscarPorId(jogador.Id);
                if (jogadorTemp == null)
                    throw new Exception("Jogador não encontrado");

                jogadorTemp.Email = jogador.Email;
                jogadorTemp.Senha = jogador.Senha;
                jogadorTemp.DataNascimento = jogador.DataNascimento;
                jogadorTemp.Imagem = jogador.Imagem;
                jogadorTemp.JogadorJogos = jogador.JogadorJogos;
                jogadorTemp.Nome = jogador.Nome;
                jogadorTemp.UrlImagem = jogador.UrlImagem;

                _ctx.Jogadores.Update(jogadorTemp);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove um jogador
        /// </summary>
        /// <param name="id">ID do jogador</param>
        public void Remover(Guid id)
        {
            try
            {
                Jogador jogadorRemove = BuscarPorId(id);

                _ctx.Jogadores.Remove(jogadorRemove);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        #endregion
    }
}
