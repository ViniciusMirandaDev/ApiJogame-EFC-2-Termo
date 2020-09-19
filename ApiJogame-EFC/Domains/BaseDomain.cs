using System;
using System.ComponentModel.DataAnnotations;

namespace ApiJogame_EFC.Domains
{
    public abstract class BaseDomain
    {
        [Key]
        // Private é necessário aqui
        public Guid Id { get; private set; }

        public BaseDomain()
        {
            Id = new Guid();
        }

        public void setId(Guid id)
        {
            id = Id;
        }
    }
}
