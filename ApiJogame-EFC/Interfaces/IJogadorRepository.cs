using ApiJogame_EFC.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiJogame_EFC.Interfaces
{
    interface IJogadorRepository
    {
        /// <summary>
        /// Lista todos os jogadores
        /// </summary>
        /// <returns>Lista com jogadores/returns>
        List<Jogador> Listar();

        /// <summary>
        /// Busca os jogadores por id
        /// </summary>
        /// <param name="id">ID do jogador</param>
        /// <returns>Jogador</returns>
        Jogador BuscarPorId(Guid id);

        /// <summary>
        /// Adiciona jogos ao jogador
        /// </summary>
        /// <param name="jogosJogador">Lista jogos jogador</param>
        /// <returns>Jogo adicionado ao jogador</returns>
        Jogador AdicionarJogo(List<JogosJogadores> jogosJogador);

        /// <summary>
        /// Adiciona um novo jogador
        /// </summary>
        /// <param name="jogador">Objeto Jogador</param>
        void Adicionar(Jogador jogador);

        /// <summary>
        /// Remove um jogador
        /// </summary>
        /// <param name="id">ID do Jogador</param>
        void Remover(Guid id);

        /// <summary>
        /// Edita um jogador
        /// </summary>
        /// <param name="jogador">Objeto Jogador</param>
        void Editar(Jogador jogador);
    }
}
