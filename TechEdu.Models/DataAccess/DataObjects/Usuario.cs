using System;
using System.Collections.Generic;

namespace TechEdu.Models.DataAccess.DataObjects
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Senha { get; set; } = null!;
        public string? Nome { get; set; }
        public int PapelPessoaId { get; set; }
        public string? UsuarioHash { get; set; }

        public virtual PapelPessoa PapelPessoa { get; set; } = null!;
    }
}
