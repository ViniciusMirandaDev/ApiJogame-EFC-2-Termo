using ApiJogame_EFC.Contexts;
using ApiJogame_EFC.Domains;
using ApiJogame_EFC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiJogame_EFC.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private readonly JogadorContext _ctx;

        public JogoRepository()
        {
            _ctx = new JogadorContext();
        }

        #region Leitura
        /// <summary>
        /// Busca o jogo por Id
        /// </summary>
        /// <param name="id">Id do jogo</param>
        /// <returns>Jogo</returns>
        public Jogo BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Jogos.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Jogo> BuscarPorNome(string nome)
        {
            try
            {
                //Retornamos uma lista de jogos onde Nome contenha nossa string nome
                return _ctx.Jogos.Where(c => c.Nome.Contains(nome)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Jogo> Listar()
        {
            try
            {
                //Retornamos uma lista de jogos 
                return _ctx.Jogos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Gravação
        /// <summary>
        /// Adiciona um jogo ao nosso contexto
        /// </summary>
        /// <param name="jogo">Jogo a ser adicionado</param>
        public void Adicionar(Jogo jogo)
        {
            try
            {
                _ctx.Jogos.Add(jogo);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Edita um jogo
        /// </summary>
        /// <param name="jogo">Jogo a ser editado</param>
        public void Editar(Jogo jogo)
        {
            try
            {
                Jogo _jogo = BuscarPorId(jogo.Id);

                //Verifica se existe o jogo a ser editado
                //Caso não exista irá nos gerar uma Exception
                if (_jogo == null)
                    throw new Exception("Jogo não encontrado");

                //Se existir então suas propriedades serão alteradas
                _jogo.Nome = jogo.Nome;
                _jogo.Descricao = jogo.Descricao;
                _jogo.DataLancamento = jogo.DataLancamento;

                _ctx.Update(jogo);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove um produto
        /// </summary>
        /// <param name="id">Id do jogo</param>
        public void Remover(Guid id)
        {
            try
            {
                Jogo _jogo = BuscarPorId(id);

                _ctx.Jogos.Remove(_jogo);

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
