using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiJogame_EFC.Domains
{
    public class JogosJogadores : BaseDomain
    {
        public Guid IdJogador { get; set; }
        [ForeignKey("IdJogador")]
        public Jogador Jogador{ get; set; }
        public Guid IdJogo { get; set; }
        [ForeignKey("IdJogador")]
        public Jogo Jogo { get; set; }

    }
}
