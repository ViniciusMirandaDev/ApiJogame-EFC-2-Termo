using ApiJogame_EFC.Domains;
using System;
using System.Collections.Generic;

namespace ApiJogame_EFC.Interfaces
{
    interface IJogoRepository
    {
        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns>Lista de jogos</returns>
        List<Jogo> Listar();
        /// <summary>
        /// Busca os jogos por nome
        /// </summary>
        /// <param name="nome">Nome do jogo</param>
        /// <returns>Lista de jogos</returns>
        List<Jogo> BuscarPorNome(string nome);
        /// <summary>
        /// Busca um jogo por Id
        /// </summary>
        /// <param name="id">Id do jogo</param>
        /// <returns>Jogo</returns>
        Jogo BuscarPorId(Guid id);
        /// <summary>
        /// Adiciona um jogo
        /// </summary>
        /// <param name="jogo">Objeto jogo</param>
        void Adicionar(Jogo jogo);
        /// <summary>
        /// Remove um jogo pelo seu Id
        /// </summary>
        /// <param name="id">Id do jogo</param>
        void Remover(Guid id);
        /// <summary>
        /// Edita um jogo
        /// </summary>
        /// <param name="jogo">Objeto jogo</param>
        void Editar(Jogo jogo);
    }
}
