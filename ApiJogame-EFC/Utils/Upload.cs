using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ApiJogame_EFC.Utils
{
    public static class Upload
    {
        public static string Local(IFormFile file)
        {
            //Gera um nome com Guid depois o transforma para string, depois tira os "-" do nome e adiciona o tipo do arquivo que vai ser adicionado
            var nomeArquivo = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);

            //Pega o diretório da aplicação corrente, 
            //concatena com a pasta que irá salvar o arquivo e logo após concatena com o nom do arquivo
            //c://users//User1//aplicacao//upload///imagens//ejifns34878eo.png
            var caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), @"wwwRoot\upload\imagens", nomeArquivo);

            //Gera um FileStream que irá armazenar o código da imagem
            using var streamImage = new FileStream(caminhoArquivo, FileMode.Create);

            //Copia a nossa imagem para o local quirá armazená-la
            file.CopyTo(streamImage);

            return "https://localhost:44303/upload/imagens" + nomeArquivo;
        }
    }
}
