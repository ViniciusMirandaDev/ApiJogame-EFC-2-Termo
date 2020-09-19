using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiJogame_EFC.Domains
{
    public class Jogador : BaseDomain
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public List<Jogo> JogadorJogos { get; set; }

        //Não mapeia no banco de dados
        [NotMapped]
        //Ignora a imagem, para que assim apenas a url apareça
        [JsonIgnore]
        public IFormFile Imagem { get; set; }
        //Url da Imagem salva localmente
        public string UrlImagem { get; set; }

        public Jogador()
        {
            JogadorJogos = new List<Jogo>();
        }
    }
}
