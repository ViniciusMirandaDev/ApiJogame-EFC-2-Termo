
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiJogame_EFC.Domains
{
    public class Jogo : BaseDomain
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Descricao { get; set; }

        //Não irá mostra-lo no banco de dados
        [NotMapped]
        [JsonIgnore] // Usamos para mostrar apenas a Url e não a imagem
        public IFormFile Imagem { get; set; }
        //Url da imagem salva localmente
        public string UrlImagem { get; set; }

        public DateTime DataLancamento { get; set; }
    }
}
