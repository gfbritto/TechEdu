using System;
using System.Collections.Generic;

namespace TechEdu.Models.DataAccess.DataObjects
{
    public partial class Endereco
    {
        public int Id { get; set; }
        public string? Cep { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string Logradouro { get; set; } = null!;
        public int PessoaId { get; set; }

        public virtual Pessoa Pessoa { get; set; } = null!;
    }
}
